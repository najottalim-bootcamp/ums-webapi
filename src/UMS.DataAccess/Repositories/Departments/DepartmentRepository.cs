namespace UMS.DataAccess.Repositories.Departments
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public async ValueTask<int> CreateAsync(DepartmentDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Department VALUES(@Name,@FacultyId)";
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

                string query = "DELETE FROM Department WHERE Id=@Id";
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

        public async ValueTask<IList<Department>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Department";
                var result = (await _connection.QueryAsync<Department>(query)).ToList();

                return result;
            }
            catch
            {
                return new List<Department>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Department> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Department where Id = @Id;";
                var result = (await _connection.QueryFirstOrDefaultAsync<Department>(query, new { Id = Id }));
                return result;
            }
            catch
            {
                return new Department();
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

                string query = "SELECT COUNT(*) FROM Department;";
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

        public async ValueTask<IList<Department>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Department ORDER BY Id DESC " +
                                  $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
                var result = (await _connection.QueryAsync<Department>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Department>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, DepartmentDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE Department SET Name = @Name,FacultyId=@FacultyId WHERE id={Id};";
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

