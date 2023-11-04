using UMS.DataAccess.Dtos.EduForm;
using UMS.Domain.Entities.EduModels;

namespace UMS.DataAccess.Repositories.EduFormPositions
{
    public class EduFormRepository : BaseRepository, IEduFormRepository
    {
        

        public async ValueTask<int> CreateAsync(EduFormDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO EduForm VAlUES(@Name,@IsActive, @CreatedAt);";
                int result = await _connection.ExecuteAsync(query, model);
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

        public async ValueTask<int> DeleteAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "DELETE FROM EduForm WHERE Id = @Id;";
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

        public async ValueTask<IList<EduForm>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM EduForm;";
                var result = (await _connection.QueryAsync<EduForm>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<EduForm>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<EduForm> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM EduForm where Id = @Id;";
                var result = (await _connection.QueryFirstOrDefaultAsync<EduForm>(query,new {Id = Id}));
                return result;
            }
            catch
            {
                return new EduForm();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async  ValueTask<long> GetCountAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT COUNT(*) FROM EduForm;";
                var result = (_connection.ExecuteScalar<long>(query));
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

        public async ValueTask<IList<EduForm>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM EduForm ORDER BY Id DESC " +
                                  $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
                var result = (await _connection.QueryAsync<EduForm>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<EduForm>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        

        public async ValueTask<int> UpdateAsync(long Id, EduFormDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "UPDATE EduForm SET Name = @Name,IsActive = @IsActive, UpdatedAt = @UpdatedAt;";
                var result = (await _connection.ExecuteAsync(query));
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
}
