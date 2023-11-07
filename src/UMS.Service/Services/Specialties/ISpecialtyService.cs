﻿namespace UMS.Service.Specialties
{
	public interface ISpecialtyService
	{
        public ValueTask<bool> CreateAsync(SpecialtyDTO specialtyDto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<SpecialtyViewModel> GetByIdAsync(long id);
        public ValueTask<IList<SpecialtyViewModel>> GetAllAsync();
    }
}

