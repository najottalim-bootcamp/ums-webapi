using UMS.Service.Dtos.Education;

namespace UMS.Service.Faculties
{
    public interface IFacultyService
    {
        public Task<bool> CreateAsync(FacultyDto dto);
        public Task<IList<Faculty>> GetAllAsync();
        public Task<Faculty> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(long facId, FacultyDto dto);
        public Task<bool> DeleteAsync(long id);
    }
}
