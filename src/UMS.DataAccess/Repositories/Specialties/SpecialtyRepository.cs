using UMS.DataAccess.Dtos.Education;
namespace UMS.DataAccess.Repositories.Specialties
{
    public class SpecialtyRepository : BaseRepository, ISpecialtyRepository
    {
        public async ValueTask<int> CreateAsync(Specialty model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Specialty(Name, DepartmentId) VALUES(@Name, @DepartmentId);";
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

                string query = "DELETE FROM Specialty WHERE Id = @Id;";
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

        public async ValueTask<IList<Specialty>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Specialty;";
                var result = (await _connection.QueryAsync<Specialty>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Specialty>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Specialty> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Specialty WHERE Id = @Id";
                var specialty = await _connection.QueryFirstOrDefaultAsync<Specialty>(query, new { Id = Id });

                return specialty;
            }
            catch
            {
                return new Specialty();
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

                string query = "SELECT COUNT(*) FROM Specialty;";
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

        public async ValueTask<IList<Specialty>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM Specialty ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var specialties = (await _connection.QueryAsync<Specialty>(query)).ToList();
                return specialties;
            }
            catch
            {
                return new List<Specialty>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, Specialty model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE Specialty SET Name = @Name WHERE id = {Id};";
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
