namespace UMS.DataAccess.Repositories.Cities
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        //Check it
        public async ValueTask<int> CreateAsync(City model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO City(Name, Created_At)  VAlUES(@Name, @CreatedAt);";

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

                string query = "DELETE FROM City WHERE Id = @Id;";
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

        public async ValueTask<IList<City>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM City;";
                var result = (await _connection.QueryAsync<City>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<City>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<City> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM City WHERE Id = @Id";
                var city = await _connection.QueryFirstOrDefaultAsync<City>(query, new { Id = Id });

                return city;
            }
            catch
            {
                return new City();
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

                string query = "SELECT COUNT(*) FROM City;";
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

        public async ValueTask<IList<City>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM City ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var cities = (await _connection.QueryAsync<City>(query)).ToList();
                return cities;
            }
            catch
            {
                return new List<City>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
        //Check it
        public async ValueTask<int> UpdateAsync(long Id, City model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE City SET Name=@Name, Updated_At = @UpdatedAt WHERE id={Id};";

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
