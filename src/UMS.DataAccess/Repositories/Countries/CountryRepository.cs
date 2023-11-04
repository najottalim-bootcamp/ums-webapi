namespace UMS.DataAccess.Repositories.CountryPositions
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        public async ValueTask<int> CreateAsync(CountryDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Country VAlUES(@Name);";
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

                string query = "DELETE FROM Country WHERE Id = @Id;";
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

        public async ValueTask<IList<Country>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Country;";
                var result = (await _connection.QueryAsync<Country>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Country>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Country> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Country where Id = @Id;";
                var result = (await _connection.QueryFirstOrDefaultAsync<Country>(query, new { Id = Id }));
                return result;
            }
            catch
            {
                return new Country();
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

                string query = "SELECT COUNT(*) FROM Country;";
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

        public async ValueTask<IList<Country>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Country ORDER BY Id DESC " +
                                 $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
                var result = (await _connection.QueryAsync<Country>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Country>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, CountryDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "UPDATE Country SET Name = @Name CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt;";
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
