using static Dapper.SqlMapper;

namespace UMS.DataAccess.Repositories.AcadPositions;

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

    public async ValueTask<IList<AcadPosition>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM AcadPosition;";
            var result = (await _connection.QueryAsync<AcadPosition>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<AcadPosition>();
        }
        finally
        {
            await _connection.CloseAsync(); 
        }
    }

    public async ValueTask<AcadPosition?> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM AcadPosition WHERE Id = @Id";
            var acadPosition = await _connection.QueryFirstOrDefaultAsync<AcadPosition>(query, new { Id = Id});

            return acadPosition;
        }
        catch
        {
            return new AcadPosition();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<long> GetCountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM AcadPosition;";
            long count = _connection.ExecuteScalar<long>(query);

            return count;
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

    public async ValueTask<IList<AcadPosition>> GetPageItems(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM AcadPosition ORDER BY Id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

            var acadPositions = (await _connection.QueryAsync<AcadPosition>(query)).ToList();
            return acadPositions;
        }
        catch
        {
            return new List<AcadPosition>();
        }
        finally 
        { 
            await _connection.CloseAsync(); 
        }
    }

    public async ValueTask<int> UpdateAsync(long Id, AcadPositionDto model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE AcadPosition SET Name=@Name WHERE id={Id};";
            var result = await _connection.ExecuteAsync(query, model);

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
}
