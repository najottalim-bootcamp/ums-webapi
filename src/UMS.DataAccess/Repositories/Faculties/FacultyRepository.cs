namespace UMS.DataAccess.Repositories.Faculties
{
    public class FacultyRepository : BaseRepository, IFacultyRepository
    {
        public async ValueTask<int> CreateAsync(FacultyDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Faculty VALUES(@Name, @Description, @BranchId)";
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

                string query = "DELETE FROM Faculty WHERE Id=@Id";
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

        public async ValueTask<IList<Faculty>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Faculty";
                var result = (await _connection.QueryAsync<Faculty>(query)).ToList();

                return result;
            }
            catch
            {
                return new List<Faculty>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Faculty> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Faculty where Id = @Id;";
                var result = (await _connection.QueryFirstOrDefaultAsync<Faculty>(query, new { Id = Id }));
                return result;
            }
            catch
            {
                return new Faculty();
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

                string query = "SELECT COUNT(*) FROM Faculty;";
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

        public async ValueTask<IList<Faculty>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Faculty ORDER BY Id DESC " +
                                  $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
                var result = (await _connection.QueryAsync<Faculty>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Faculty>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, FacultyDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "UPDATE Faculty SET Name = @Name,Description=@Description,BranchId=@BranchId";
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

