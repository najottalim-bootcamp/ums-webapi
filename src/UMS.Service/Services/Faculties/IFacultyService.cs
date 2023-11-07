using UMS.Service.Dtos.Education;

namespace UMS.Service.Faculties
{
    public interface IFacultyService
    {
        public ValueTask<bool> CreateAsync(FacultyDto dto);
        public ValueTask<IList<Faculty>> GetAllAsync();
        public ValueTask<Faculty> GetByIdAsync(long id);
        public ValueTask<bool> UpdateAsync(long facId, FacultyDto dto);
        public ValueTask<bool> DeleteAsync(long id);
    }
}
