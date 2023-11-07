using UMS.Service.Dtos.University;

namespace UMS.Service.Services.Universities;

public interface IUniversityService
{
    public ValueTask<bool> CreateAsync(UniversityDto dto);
    public ValueTask<bool> UpdateAsync(long id, UniversityDto dto);
    public ValueTask<University> GetByIdAsync(long id);
    public ValueTask<IList<University>> GetAllAsync();
}
