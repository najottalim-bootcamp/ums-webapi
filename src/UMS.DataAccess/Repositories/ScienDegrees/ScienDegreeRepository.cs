namespace UMS.DataAccess.Repositories.ScienDegrees
{
    public class ScienDegreeRepository : BaseRepository, IScienDegreeRepository
    {
        public async ValueTask<int> CreateAsync(ScienDegreeDTO model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO ScienDegree VALUES(@Name, @CreatedAt);";
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

                string query = "DELETE FROM ScienDegree WHERE Id = @Id;";
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

        public async ValueTask<IList<ScienDegree>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM ScienDegree;";
                var result = (await _connection.QueryAsync<ScienDegree>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<ScienDegree>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<ScienDegree> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM ScienDegree WHERE Id = @Id";
                var scienDegree = await _connection.QueryFirstOrDefaultAsync<ScienDegree>(query, new { Id = Id });

                return scienDegree;
            }
            catch
            {
                return new ScienDegree();
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

                string query = "SELECT COUNT(*) FROM ScienDegree;";
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

        public async ValueTask<IList<ScienDegree>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM ScienDegree ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var scienDegrees = (await _connection.QueryAsync<ScienDegree>(query)).ToList();
                return scienDegrees;
            }
            catch
            {
                return new List<ScienDegree>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, ScienDegreeDTO model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE ScienDegree SET Name = @Name, UpdatedAt = @UpdatedAt WHERE id = {Id};";
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
}
