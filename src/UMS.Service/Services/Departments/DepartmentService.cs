using UMS.Service.Dtos.Education;

namespace UMS.Service.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository repository;
        public DepartmentService(IDepartmentRepository _repository)
        {
            repository = _repository;
        }

        public async ValueTask<bool> CreateAsync(DepartmentDto dto)
        {
            Department department = new Department()
            {
                Name = dto.Name,
                FacultyID = dto.FacultyID,
            };
            var result = await repository.CreateAsync(department);
            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Department res = await repository.GetByIdAsync(id);
            if (res is null)
            {
                throw new DepartmentNotFoundException();
            }
            var result = await repository.DeleteAsync(id);
            return result > 0;
        }

        public async ValueTask<IList<Department>> GetAllAsync()
        {
            IList<Department> result = await repository.GetAllAsync();
            return result;
        }

        public async ValueTask<Department> GetByIdAsync(long id)
        {
            Department result = await repository.GetByIdAsync(id);
            if (result is null)
            {
                throw new DepartmentNotFoundException();
            }
            return result;
        }

        public async ValueTask<bool> UpdateAsync(long id, DepartmentDto dto)
        {
            Department result = await repository.GetByIdAsync(id);
            if ( result is null)
            {
                throw new DepartmentNotFoundException();
            }
            result.Name = dto.Name;
            result.FacultyID = dto.FacultyID;

            var res = await repository.UpdateAsync(id, result);
            return res > 0;
        }
    }
}
