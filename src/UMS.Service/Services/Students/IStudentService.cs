using UMS.Service.Dtos.Students;
using UMS.Service.ViewModels.Students;

namespace UMS.Service.Services.Students;

public interface IStudentService
{
    public Task<long> CountAsync();
    public ValueTask<bool> CreateAsync(StudentDto dto);
    public ValueTask<bool> UpdateAsync(long id, StudentDto dto);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<StudentViewModel> GetByIdAsync(long id);
    public ValueTask<IList<StudentViewModel>> GetAllAsync();
    public ValueTask<IList<StudentViewModel>> GetPageItems(PaginationParams @params);
}
