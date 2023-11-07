using UMS.Service.Dtos.Teachers;
using UMS.Service.ViewModels.Teachers;

namespace UMS.Service.Services.Teachers;

public interface ITeacherService
{
    public Task<long> CountAsync();
    public ValueTask<bool> CreateAsync(TeacherDTO dto);
    public ValueTask<bool> UpdateAsync(long id, TeacherDTO dto);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<TeacherViewModel> GetByIdAsync(long id);
    public ValueTask<IList<TeacherViewModel>> GetAllAsync();
    public ValueTask<IList<TeacherViewModel>> GetPageItems(PaginationParams @params);
}
