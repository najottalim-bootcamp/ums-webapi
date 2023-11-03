namespace UMS.DataAccess.Repositories.AcadPosition;

public class AcadPositionRepository : BaseRepository, IAcadPositionRepository
{
    public async ValueTask<int> CreateAsync(AcadPositionDto model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO AcadPosition VAlUES(@Name, @CreatedAt, @UpdatedAt);";
            int result = await _connection.ExecuteAsync(query, model);
            return result;
        }
        catch
        {
            return 0;
        }
        finally 
        { 
          await  _connection.CloseAsync(); 
        }
    }

    public async ValueTask<int> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "DELETE FROM AcadPosition WHERE Id = @Id;";
            int result = await _connection.ExecuteAsync(query, new { Id = Id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<IList<Domain.Entities.Teacher.AcadPosition>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM AcadPosition;";
            var result = (await _connection.QueryAsync<Domain.Entities.Teacher.AcadPosition>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Domain.Entities.Teacher.AcadPosition>();
        }
        finally
        {
            await _connection.CloseAsync(); 
        }
    }

    public ValueTask<Domain.Entities.Teacher.AcadPosition> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<IList<Domain.Entities.Teacher.AcadPosition>> GetPageItems(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<int> UpdateAsync(long Id, AcadPositionDto model)
    {
        throw new NotImplementedException();
    }
}
