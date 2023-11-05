using UMS.DataAccess.Dtos.Discipline;

namespace UMS.Service.Disciplines
{
    public interface IDistiplineService
    {
        public Task<long> CountAsync();
        public ValueTask<bool> CreateAsync(DisciplineDto disciplineDto);
        public ValueTask<bool> UpdateAsync(long id, DisciplineDto disciplineDto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<Discipline> GetByIdAsync(long id);
        public ValueTask<IList<Discipline>> GetAllAsync();
    }
}
