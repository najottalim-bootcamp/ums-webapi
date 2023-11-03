namespace UMS.DataAccess.Repositories;

public interface IBaseRepository<TModel, TView> where TModel : class
{
    public ValueTask<int> CreateAsync(TView model);
    public ValueTask<int> UpdateAsync(long Id, TView model);
    public ValueTask<int> DeleteAsync(long Id);
    public ValueTask<TModel> GetByIdAsync(long Id);
    public ValueTask<IList<TModel>> GetAllAsync();
    public ValueTask<IList<TModel>> GetPageItems(PaginationParams @params);
    public ValueTask<long> GetCountAsync();

}
