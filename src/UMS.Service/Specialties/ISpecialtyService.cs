namespace UMS.Service.Specialties
{
	public interface ISpecialtyService
	{
        public ValueTask<bool> CreateAsync(SubjectDto contractDto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<Subject> GetByIdAsync(long id);
        public ValueTask<IList<Subject>> GetAllAsync();
    }
}

