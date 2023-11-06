using UMS.Service.Dtos.Education;

namespace UMS.Service.SpecialtyEduForms
{
    public interface ISpecialtyEduFormService
    {
        public Task<long> CountAsync();
        public ValueTask<bool> CreateAsync(SpecialtyEduFormDTO specialtyEduFormDTO);
        public ValueTask<bool> UpdateAsync(long id, SpecialtyEduFormDTO specialtyEduFormDTO);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<SpecialtyEduForm> GetByIdAsync(long id);
        public ValueTask<IList<SpecialtyEduForm>> GetAllAsync();
    }
}
