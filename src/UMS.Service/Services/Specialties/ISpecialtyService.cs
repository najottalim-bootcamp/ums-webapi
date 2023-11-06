using UMS.Service.Dtos.Education;

namespace UMS.Service.Specialties
{
	public interface ISpecialtyService
	{
        public ValueTask<bool> CreateAsync(SpecialtyDTO specialtyDto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<Specialty> GetByIdAsync(long id);
        public ValueTask<IList<Specialty>> GetAllAsync();
    }
}

