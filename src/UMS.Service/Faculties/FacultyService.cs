﻿using UMS.DataAccess.Dtos.Education;
using UMS.DataAccess.Repositories.Faculties;
using UMS.Domain.Entities.EduModels;
using UMS.Domain.Exceptions.Education;
using UMS.Service.Faculties;

public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _repository;
    public FacultyService(IFacultyRepository facultyrepository)
    {
        _repository = facultyrepository;
    }
    public async Task<bool> CreateAsync(FacultyDto dto)
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

    public async Task<bool> DeleteAsync(long id)
    {
        Faculty res = await _repository.GetByIdAsync(id);
        if (res == null)
        {
            throw new FacultyNotFoundException();
        }
        var result = await _repository.DeleteAsync(id);
        return result > 0;
    }

    public async Task<IList<Faculty>> GetAllAsync()
    {
        IList<Faculty> result = await _repository.GetAllAsync();
        return result;
    }

    public async Task<Faculty> GetByIdAsync(long id)
    {
        Faculty result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            throw new FacultyNotFoundException();
        }
        return result;
    }

    public async Task<bool> UpdateAsync(long facId, FacultyDto dto)
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