using UMS.DataAccess.Dtos.Education;
using UMS.Domain.Entities.EduModels;

namespace UMS.Service.Departments
{
    public interface IDepartmentService
    {
        public Task<bool> CreateAsync(DepartmentDto dto);
        public Task<IList<Department>> GetAllAsync();
        public Task<Department> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(long id, DepartmentDto department);
        public Task<bool> DeleteAsync(long id);
    }
}
