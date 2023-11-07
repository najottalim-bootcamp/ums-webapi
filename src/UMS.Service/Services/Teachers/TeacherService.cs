using UMS.DataAccess.Repositories.AcadPositions;
using UMS.DataAccess.Repositories.ScienDegrees;
using UMS.DataAccess.Repositories.Teachers;
using UMS.Domain.Entities.People;
using UMS.Domain.Entities.Teacher;
using UMS.Domain.Exceptions.Teachers;
using UMS.Service.Dtos.Teachers;
using UMS.Service.ViewModels.Teachers;

namespace UMS.Service.Services.Teachers;

public class TeacherService : ITeacherService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IAcadPositionRepository _positionRepository;
    private readonly IScienDegreeRepository _degreeRepository;
    private readonly IPersonalDataRepository _userRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IFileService _fileService;

    public TeacherService(
        IDepartmentRepository departmentRepository,
        IAcadPositionRepository positionRepository,
        IScienDegreeRepository degreeRepository,
        IPersonalDataRepository userRepository,
        ITeacherRepository teacherRepository,
        IFileService fileService)
    {
        _departmentRepository = departmentRepository;
        _positionRepository = positionRepository;
        _degreeRepository = degreeRepository;
        _teacherRepository = teacherRepository;
        _userRepository = userRepository;
        _fileService = fileService;
    }

    public async Task<long> CountAsync()
    {
        long count = await _teacherRepository.GetCountAsync();
        return count;
    }

    public async ValueTask<bool> CreateAsync(TeacherDTO dto)
    {
        string imagePath = await _fileService.UploadAvatarAsync(dto.UserAvatar);

        PersonalData personalData = new PersonalData()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            CityId = dto.CityId,
            CountryId = dto.CountryId,
            Gender = dto.Gender,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            ImagePath = imagePath,
            CreatedAt = DateTime.Now,
        };

        int resultUser = await _userRepository.CreateAsync(personalData);

        Teacher teacher = new Teacher()
        {
            DepartmentId = dto.DepartmentId,
            PersonalDataId = personalData.Id,
            AcadPositionId = dto.AcadPositionId,
            ScienDegreeId = dto.ScienDegreeId,
        };

        int resultTeacher = await _teacherRepository.CreateAsync(teacher);

        return resultUser > 0 && resultTeacher > 0;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        Teacher teacher = await _teacherRepository.GetByIdAsync(id);
        if (teacher == null) throw new TeacherNotFoundException();

        PersonalData user = await _userRepository.GetByIdAsync(teacher.PersonalDataId);
        if (user == null) throw new PersonalDataNotFoundException();

        bool imagePath = await _fileService.DeleteAvatarAsync(user.ImagePath);
        if (imagePath == false) throw new ImageNotFoundException();

        int teacherDelete = await _teacherRepository.DeleteAsync(id);
        int userDelete = await _userRepository.DeleteAsync(teacher.PersonalDataId);

        return teacherDelete > 0 && userDelete > 0;
    }

    public async ValueTask<IList<TeacherViewModel>> GetAllAsync()
    {
        IList<Teacher> teachers = await _teacherRepository.GetAllAsync();
        IList<PersonalData> users = await _userRepository.GetAllAsync();
        IList<Department> departments = await _departmentRepository.GetAllAsync();
        IList<AcadPosition> acadPositions = await _positionRepository.GetAllAsync();
        IList<ScienDegree> scienDegrees = await _degreeRepository.GetAllAsync();

        var joinedData = teachers.Join(users, teacher => teacher.PersonalDataId,
                                user => user.Id, (teacher, user) => new
                                {
                                    Teacher = teacher,
                                    User = user
                                })
                            .Join(departments, data => data.Teacher.DepartmentId,
                                department => department.Id, (data, department) => new
                                {
                                    Teacher = data.Teacher,
                                    User = data.User,
                                    Department = department
                                })
                            .Join(acadPositions, data => data.Teacher.AcadPositionId,
                                position => position.Id, (data, position) => new
                                {
                                    Teacher = data.Teacher,
                                    User = data.User,
                                    Department = data.Department,
                                    AcadPosition = position
                                })
                            .Join(scienDegrees, data => data.Teacher.ScienDegreeId,
                                degree => degree.Id, (data, degree) => new
                                {
                                    Teacher = data.Teacher,
                                    User = data.User,
                                    Department = data.Department,
                                    AcadPosition = data.AcadPosition,
                                    ScienDegree = degree
                                }).Select(data => new TeacherViewModel
                                {
                                    TeacherId = data.Teacher.Id,
                                    FirstName = data.User.FirstName,
                                    MiddleName = data.User.MiddleName,
                                    LastName = data.User.LastName,
                                    Email = data.User.Email,
                                    Gender = data.User.Gender,
                                    Position = data.AcadPosition.Name,
                                    ScienDegree = data.ScienDegree.Name,
                                    Deparment = data.Department.Name,
                                    PhoneNumber = data.User.PhoneNumber,
                                    UserAvatar = data.User.ImagePath
                                }).ToList();

        return joinedData;
    }

    public async ValueTask<TeacherViewModel> GetByIdAsync(long id)
    {
        Teacher teacher = await _teacherRepository.GetByIdAsync(id);
        if (teacher is null) throw new TeacherNotFoundException();

        PersonalData user = await _userRepository.GetByIdAsync(teacher.PersonalDataId);
        if (user is null) throw new PersonalDataNotFoundException();

        AcadPosition position = await _positionRepository.GetByIdAsync(teacher.AcadPositionId);
        if (position is null) throw new AcadPositionNotFoundException();

        ScienDegree degree = await _degreeRepository.GetByIdAsync(teacher.ScienDegreeId);
        if (degree is null) throw new ScianDegreeNotFoundException();

        Department department = await _departmentRepository.GetByIdAsync(teacher.DepartmentId);
        if (department is null) throw new DepartmentNotFoundException();

        TeacherViewModel teacherViewModel = new TeacherViewModel()
        {
            TeacherId = teacher.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Email = user.Email,
            Gender = user.Gender,
            Position = position.Name,
            ScienDegree = degree.Name,
            Deparment = department.Name,
            PhoneNumber = user.PhoneNumber,
            UserAvatar = user.ImagePath,
        };

        return teacherViewModel;
    }

    public ValueTask<IList<TeacherViewModel>> GetPageItems(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(long id, TeacherDTO dto)
    {
        Teacher teacher = await _teacherRepository.GetByIdAsync(id);
        if (teacher is null) throw new TeacherNotFoundException();

        Teacher teacherUpdate = new Teacher()
        {
            DepartmentId = dto.DepartmentId,
            AcadPositionId = dto.AcadPositionId,
            ScienDegreeId = dto.ScienDegreeId,
        };

        PersonalData user = await _userRepository.GetByIdAsync(teacher.PersonalDataId);
        if (user is null) throw new PersonalDataNotFoundException();

        PersonalData userUpdate = new PersonalData()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            CityId = dto.CityId,
            CountryId = dto.CountryId,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
        };

        if (dto.UserAvatar != null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(user.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.UserAvatar);
            userUpdate.ImagePath = newImagePath;
        }

        teacherUpdate.UpdatedAt = DateTime.Now;
        userUpdate.UpdatedAt = DateTime.Now;

        int resultStudent = await _teacherRepository.UpdateAsync(teacher.Id, teacherUpdate);
        int resultUser = await _userRepository.UpdateAsync(user.Id, userUpdate);

        return resultStudent > 0 && resultStudent > 0;
    }
}
