using UMS.DataAccess.Repositories.PersonalDatas;
using UMS.Domain.Entities.People;
using UMS.Domain.Exceptions.Images;
using UMS.Domain.Exceptions.Students;
using UMS.Domain.Exceptions.Users;
using UMS.Service.Dtos.Students;
using UMS.Service.ViewModels.Students;

namespace UMS.Service.Services.Students;

public class StudentService : IStudentService
{
    private readonly IPersonalDataRepository _userRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IFileService _fileService;
    private readonly IPagination _pagination;

    public StudentService(
        IPersonalDataRepository userRepository,
        IStudentRepository studentRepository,
        IFileService fileService,
        IPagination pagination)
    {
        _studentRepository = studentRepository;
        _userRepository = userRepository;
        _fileService = fileService;
        _pagination = pagination;
    }

    public async Task<long> CountAsync()
    {
        long count = await _studentRepository.GetCountAsync();
        return count;
    }

    public async ValueTask<bool> CreateAsync(StudentDto dto)
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

        Student student = new Student()
        {
            PersonalDataId = dto.PersonalDataId,
            Course = dto.Course,
            SpecialtyEduFormId = dto.SpecialtyEduFormId,
            IsActive = dto.IsActive,
            EduType = dto.EduType,
            GroupNumber = dto.GroupNumber,
            SubjectId = dto.SubjectId,
            CreatedAt = DateTime.Now,
        };

        int resultStudent = await _studentRepository.CreateAsync(student);

        return resultUser > 0 && resultStudent > 0;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        Student student = await _studentRepository.GetByIdAsync(id);
        if (student == null) throw new StudentNotFoundException();

        PersonalData user = await _userRepository.GetByIdAsync(student.PersonalDataId);
        if (user == null) throw new PersonalDataNotFoundException();

        bool imagePath = await _fileService.DeleteAvatarAsync(user.ImagePath);    
        if (imagePath == false) throw new ImageNotFoundException();

        int studentDelete = await _studentRepository.DeleteAsync(id);
        int userDelete = await _userRepository.DeleteAsync(student.PersonalDataId);

        return userDelete > 0 && userDelete > 0;
    }

    public async ValueTask<IList<StudentViewModel>> GetAllAsync()
    {
        IList<Student> students = await _studentRepository.GetAllAsync();
        IList<PersonalData> users = await _userRepository.GetAllAsync();

        var combinedData = students
            .Join(users, student => student.PersonalDataId, user => user.Id,
                    (student, user) => new StudentViewModel()
                    {
                        StudentId = student.Id,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Course = student.Course,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        IsActive = student.IsActive,
                        EduType = student.EduType,
                        GroupNumber = student.GroupNumber,
                        Gender = user.Gender,
                        UserAvatar = user.ImagePath,

                    }).ToList();

        return combinedData;
    }

    public async ValueTask<StudentViewModel> GetByIdAsync(long id)
    {
        Student student = await _studentRepository.GetByIdAsync(id);
        PersonalData user = await _userRepository.GetByIdAsync(student.PersonalDataId);

        StudentViewModel studentView = new StudentViewModel()
        {
            StudentId = student.Id,
            FirstName = user.FirstName,
            MiddleName = user.MiddleName,
            LastName = user.LastName,
            Course = student.Course,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            IsActive = student.IsActive,
            EduType = student.EduType,
            GroupNumber = student.GroupNumber,
            Gender = user.Gender,
            UserAvatar = user.ImagePath,
        };

        return studentView;
    }

    public ValueTask<IList<StudentViewModel>> GetPageItems(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(long id, StudentDto dto)
    {
        Student student = await _studentRepository.GetByIdAsync(id);
        if (student is null)  throw new StudentNotFoundException();

        Student studentUpdate = new Student()
        {
            Course = dto.Course,
            IsActive = dto.IsActive,
            EduType = dto.EduType,
            GroupNumber = dto.GroupNumber,
        };

        PersonalData user = await _userRepository.GetByIdAsync(student.PersonalDataId);
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

        if(dto.UserAvatar != null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(user.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.UserAvatar);
            userUpdate.ImagePath = newImagePath;
        }

        studentUpdate.UpdatedAt  = DateTime.Now;
        userUpdate.UpdatedAt = DateTime.Now;

        int resultStudent = await _studentRepository.UpdateAsync(student.Id, studentUpdate);
        int resultUser = await _userRepository.UpdateAsync(user.Id, userUpdate);

        return resultStudent > 0 && resultStudent > 0 ;
    }


}
