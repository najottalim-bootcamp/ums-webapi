namespace UMS.DataAccess.Repositories.Branchs
{
    public class BranchRepository : BaseRepository, IBranchRepository
    {
        public async ValueTask<int> CreateAsync(Branch model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Branch VALUES(@Name, @Address, @PostCode , @UniversityId , @CityID)";
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

                string query = "DELETE FROM Branch WHERE Id=@Id";
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

        public async ValueTask<IList<Branch>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Branch";
                var result = (await _connection.QueryAsync<Branch>(query)).ToList();

                return result;
            }
            catch
            {
                return new List<Branch>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Branch> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Branch where Id = @Id;";
                var result = (await _connection.QueryFirstOrDefaultAsync<Branch>(query, new { Id = Id }));
                return result;
            }
            catch
            {
                return new Branch();
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

                string query = "SELECT COUNT(*) FROM Branch;";
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

        public async ValueTask<IList<Branch>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Branch ORDER BY Id DESC " +
                                  $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
                var result = (await _connection.QueryAsync<Branch>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Branch>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, Branch model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE Branch SET Name = @Name, Address=@Address, PostCode=@PostCode, UniversityId=@UniversityId, CityId=@CityId WHERE id={Id};";
                var result = (await _connection.ExecuteAsync(query, model));
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

