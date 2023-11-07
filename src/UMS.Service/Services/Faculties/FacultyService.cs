using UMS.Service.Dtos.Education;

namespace UMS.Service.Services.Faculties;﻿

public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _repository;
    public FacultyService(IFacultyRepository facultyrepository)
    {
        _repository = facultyrepository;
    }
    public async ValueTask<bool> CreateAsync(FacultyDto dto)
    {
        Faculty faculty = new Faculty()
        {
            Name = dto.Name,
            BranchID = dto.BranchID,
            Description = dto.Description,
        };
        var result = await _repository.CreateAsync(faculty);
        return result > 0;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        Faculty res = await _repository.GetByIdAsync(id);
        if (res == null)
        {
            throw new FacultyNotFoundException();
        }
        var result = await _repository.DeleteAsync(id);
        return result > 0;
    }

    public async ValueTask<IList<Faculty>> GetAllAsync()
    {
        IList<Faculty> result = await _repository.GetAllAsync();
        return result;
    }

    public async ValueTask<Faculty> GetByIdAsync(long id)
    {
        Faculty result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            throw new FacultyNotFoundException();
        }
        return result;
    }

    public async ValueTask<bool> UpdateAsync(long facId, FacultyDto dto)
    {
        Faculty result = await _repository.GetByIdAsync(facId);
        if (result == null)
        {
            throw new FacultyNotFoundException();
        }

        result.Name = dto.Name;
        result.Description = dto.Description;
        result.BranchID = dto.BranchID;
        result.UpdatedAt = DateTime.Now;

        var res2 = await _repository.UpdateAsync(facId, result);
        return res2 > 0;
    }
}