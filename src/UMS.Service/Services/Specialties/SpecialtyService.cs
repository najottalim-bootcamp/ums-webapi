using UMS.Service.Dtos.Education;

namespace UMS.Service.Specialties
{
	public class SpecialtyService:ISpecialtyService
	{
        private readonly ISpecialtyRepository _specialtyRepository;

		public SpecialtyService(ISpecialtyRepository specialtyRepository)
		{
            _specialtyRepository = specialtyRepository;
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

        public async ValueTask<IList<Specialty>> GetAllAsync()
        {
            IList<Specialty> specialties = await _specialtyRepository.GetAllAsync();
            return specialties;
        }

        public async ValueTask<Specialty> GetByIdAsync(long id)
        {
            Specialty specialty = await _specialtyRepository.GetByIdAsync(id);
            if (specialty is null) throw new SpecialtyNotFoundException();

            return specialty;
        }
    }
    
}

