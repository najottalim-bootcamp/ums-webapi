using UMS.Service.Dtos.Subjects;
using UMS.Service.ViewModels.Subjects;

namespace UMS.Service.Subjects
{
	public interface ISubjectService
	{
        public ValueTask<bool> CreateAsync(SubjectDto contractDto);
        public ValueTask<bool> UpdateAsync(long id, SubjectDto contractDto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<SubjectViewModel> GetByIdAsync(long id);
        public ValueTask<IList<SubjectViewModel>> GetAllAsync();
    }
}

