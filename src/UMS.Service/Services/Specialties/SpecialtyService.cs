namespace UMS.Service.Specialties
{
    public class SpecialtyService:ISpecialtyService
	{
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IDepartmentRepository _departmentRepository;

		public SpecialtyService(ISpecialtyRepository specialtyRepository,
                                IDepartmentRepository departmentRepository)
		{
            _specialtyRepository = specialtyRepository;
            _departmentRepository = departmentRepository;
		}

        public async ValueTask<bool> CreateAsync(SpecialtyDTO specialtyDto)
        {
            Specialty specialty = new Specialty()
            {
                Name=specialtyDto.Name,
                DepartmentId=specialtyDto.DepartmentId,
            };

            int result = await _specialtyRepository.CreateAsync(specialty);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Specialty specialty = await _specialtyRepository.GetByIdAsync(id);
            if (specialty is null) throw new SpecialtyNotFoundException();

            int result = await _specialtyRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<SpecialtyViewModel>> GetAllAsync()
        {
            IList<Specialty> specialties = await _specialtyRepository.GetAllAsync();
            IList<Department> departments = await _departmentRepository.GetAllAsync();

            var combinedData = specialties
                              .Join(departments, specialty => specialty.DepartmentId, department => department.Id,
                              (specialty, department) => new SpecialtyViewModel()
                              {
                                    SpecialtyName=specialty.Name,
                                    DepartmentName=department.Name
                              }).ToList();

            return combinedData;
        }

        public async ValueTask<SpecialtyViewModel> GetByIdAsync(long id)
        {
            Specialty specialty = await _specialtyRepository.GetByIdAsync(id);
            if (specialty is null) throw new SpecialtyNotFoundException();
            Department department = await _departmentRepository.GetByIdAsync(specialty.DepartmentId);

            SpecialtyViewModel specialtyView = new SpecialtyViewModel()
            {
               SpecialtyName=specialty.Name,
               DepartmentName=department.Name
            };

            return specialtyView;
        }
    }
    
}

