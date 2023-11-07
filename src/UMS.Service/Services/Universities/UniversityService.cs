using UMS.DataAccess.Repositories.Universities;
using UMS.Service.Dtos.University;

namespace UMS.Service.Services.Universities;

public class UniversityService : IUniversityService
{
    private readonly IUniversityRepository _universityRepository;
    private readonly IFileService _fileService;

    public UniversityService(
        IUniversityRepository universityRepository,
        IFileService fileService)
    {
        _universityRepository = universityRepository;
        _fileService = fileService;
    }

    public async ValueTask<bool> CreateAsync(UniversityDto dto)
    {
        string imagePath = await _fileService.UploadImageAsync(dto.ImagePath);
    }

    public ValueTask<IList<University>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<University> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(long id, UniversityDto dto)
    {
        throw new NotImplementedException();
    }
}
