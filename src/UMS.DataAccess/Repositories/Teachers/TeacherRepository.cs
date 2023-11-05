namespace UMS.DataAccess.Repositories.Teachers
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public async ValueTask<int> CreateAsync(Teacher model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Teachers VALUES(@DepartmentId, @PersonalDataId, @AcadPositionId, @ScienDegreeId);";
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

                string query = "DELETE FROM Teachers WHERE Id = @Id;";
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

        public async ValueTask<IList<Teacher>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Teachers;";
                var result = (await _connection.QueryAsync<Teacher>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Teacher>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Teacher> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Teachers WHERE Id = @Id";
                var teacher = await _connection.QueryFirstOrDefaultAsync<Teacher>(query, new { Id = Id });

                return teacher;
            }
            catch
            {
                return new Teacher();
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

                string query = "SELECT COUNT(*) FROM Teacher;";
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

        public async ValueTask<IList<Teacher>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM Teacher ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var teachers = (await _connection.QueryAsync<Teacher>(query)).ToList();
                return teachers;
            }
            catch
            {
                return new List<Teacher>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public ValueTask<int> UpdateAsync(long Id, Teacher model)
        {
            throw new NotImplementedException();
        }
    }
}
