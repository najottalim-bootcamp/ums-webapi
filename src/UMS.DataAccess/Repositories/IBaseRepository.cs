namespace UMS.DataAccess.Repositories;

public interface IBaseRepository<TModel> where TModel : class
{
    public ValueTask<int> CreateAsync(TModel model);
    public ValueTask<int> UpdateAsync(long Id, TModel model);
    public ValueTask<int> DeleteAsync(long Id);
    public ValueTask<TModel> GetByIdAsync(long Id);
    public ValueTask<IList<TModel>> GetAllAsync();
    public ValueTask<IList<TModel>> GetPageItems(PaginationParams @params);
    public ValueTask<long> GetCountAsync();
}
