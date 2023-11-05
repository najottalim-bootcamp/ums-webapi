using UMS.DataAccess.Dtos.Subjects;
using UMS.Domain.Entities.EduModels;

namespace UMS.Service.Subjects
{
	public interface ISubjectService
	{
        public ValueTask<bool> CreateAsync(SubjectDto contractDto);
        public ValueTask<bool> UpdateAsync(long id, SubjectDto contractDto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<Subject> GetByIdAsync(long id);
        public ValueTask<IList<Subject>> GetAllAsync();
    }
}

