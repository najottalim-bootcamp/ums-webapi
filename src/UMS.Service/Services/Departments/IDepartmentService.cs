using UMS.Service.Dtos.Education;

namespace UMS.Service.Departments
{
    public interface IDepartmentService
    {
        public ValueTask<bool> CreateAsync(DepartmentDto dto);
        public ValueTask<IList<Department>> GetAllAsync();
        public ValueTask<Department> GetByIdAsync(long id);
        public ValueTask<bool> UpdateAsync(long id, DepartmentDto department);
        public ValueTask<bool> DeleteAsync(long id);
    }
}
