namespace UMS.Service.Contracts
{

    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IStudentRepository _studentRepository;

        public ContractService(IContractRepository contractRepository,
                                IFacultyRepository facultyRepository,
                                IStudentRepository studentRepository)
        {
            _contractRepository = contractRepository;
            _facultyRepository = facultyRepository;
            _studentRepository = studentRepository;
        }

        public async ValueTask<bool> CreateAsync(ContractDto contractDto)
        {
            Contract contract = new Contract()
            {
                FacultId = contractDto.FacultId,
                StudentId = contractDto.StudentId,
                Price=contractDto.Price,
            };

            int result=await _contractRepository.CreateAsync(contract);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract is null) throw new ContractNotFoundException();

            int result=await _contractRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<ContractViewModel>> GetAllAsync()
        {
            IList<Contract> contracts = await _contractRepository.GetAllAsync();
            IList<Faculty> faculties = await _facultyRepository.GetAllAsync();
            IList<Student> students = await _studentRepository.GetAllAsync();

            var combinedData = contracts
                             .Join(faculties, contract => contract.FacultId, facultie => facultie.Id,
                             (contract, facultie) => new { contract, facultie })
                             .Join(students, cs => cs.contract.StudentId, student => student.Id, (cs, student) => new ContractViewModel()
                             {
                                 FacultId=cs.facultie.Id,
                                 StudentId=student.Id,
                                 ContractPrice=cs.contract.Price,
                                 StudentCourse=student.Course,
                                 IsActive=student.IsActive,
                                 StudentEduType=student.EduType,
                                 StudentGroupNumber=student.GroupNumber,
                                 FacultyName=cs.facultie.Name,
                                 FacultyDescription=cs.facultie.Description
                             }).ToList();

            return combinedData;
        }

        public async ValueTask<ContractViewModel> GetByIdAsync(long id)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract is null) throw new ContractNotFoundException();
            Faculty faculty = await _facultyRepository.GetByIdAsync(contract.FacultId);
            Student student = await _studentRepository.GetByIdAsync(contract.StudentId);

            ContractViewModel contractView = new ContractViewModel()
            {
                FacultId = faculty.Id,
                StudentId = student.Id,
                ContractPrice = contract.Price,
                StudentCourse = student.Course,
                IsActive = student.IsActive,
                StudentEduType = student.EduType,
                StudentGroupNumber = student.GroupNumber,
                FacultyName = faculty.Name,
                FacultyDescription = faculty.Description
            };

            return contractView;
        }

        public async ValueTask<bool> UpdateAsync(long id, ContractDto contractDto)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract is null) throw new ContractNotFoundException();

            contract.FacultId = contractDto.FacultId;
            contract.StudentId = contractDto.StudentId;
            contract.Price = contractDto.Price;
            contract.UpdatedAt = DateTime.Now;

            int result = await _contractRepository.UpdateAsync(id,contract);

            return result > 0;
        }
    }
}

