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

        University university = new University()
        {
            Name = dto.Name,
            Description = dto.Description,
            ImagePath = imagePath,
        };

        int result = await _universityRepository.CreateAsync(university);
        return result > 0;
    }

    public async ValueTask<IList<University>> GetAllAsync()
    {
        IList<University> universities = await _universityRepository.GetAllAsync();
        return universities;
    }

    public async ValueTask<University> GetByIdAsync(long id)
    {
        University university = await _universityRepository.GetByIdAsync(id);
        if(university is null) throw new UniversityNotFoundException();

        return university;
    }

    public async ValueTask<bool> UpdateAsync(long id, UniversityDto dto)
    {
        University university = await _universityRepository.GetByIdAsync(id);
        if (university is null) throw new UniversityNotFoundException();

        if (dto.ImagePath is not null)
        {
            var image = await _fileService.DeleteAvatarAsync(university.ImagePath);
            if (image == false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadAvatarAsync(dto.ImagePath);

            university.ImagePath = newImagePath;
        }

        university.Name = dto.Name;
        university.Description = dto.Description;

        int result = await _universityRepository.UpdateAsync(university.Id, university);

        return result > 0;
    }
}
