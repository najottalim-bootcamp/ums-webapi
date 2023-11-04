using UMS.DataAccess.Dtos.Discipline;
using UMS.Domain.Entities.EduModels;

namespace UMS.DataAccess.Repositories.Disciplines
{
    public class DisciplineRepository : BaseRepository, IDisciplineRepository
    {
        public async ValueTask<int> CreateAsync(DisciplineDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO Discipline(Name,DepartmentId,TeacherId,LectureHours,PracticeHours,CreatedAt)" +
                    " VAlUES(@Name,@DepartmentId,@TeacherId,@LectureHours,@PracticeHours,@CreatedAt);";
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

                string query = "DELETE FROM Discipline WHERE Id = @Id;";
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

        public async ValueTask<IList<Discipline>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Discipline;";
                var result = (await _connection.QueryAsync<Discipline>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Discipline>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Discipline> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Discipline WHERE Id = @Id";
                var discipline = await _connection.QueryFirstOrDefaultAsync<Discipline>(query, new { Id = Id });

                return discipline;
            }
            catch
            {
                return new Discipline();
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

                string query = "SELECT COUNT(*) FROM Discipline;";
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

        public async ValueTask<IList<Discipline>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM Discipline ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var discipline = (await _connection.QueryAsync<Discipline>(query)).ToList();
                return discipline;
            }
            catch
            {
                return new List<Discipline>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, DisciplineDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE Discipline SET Name = @Name,DepartmentId = @DepartmentId,TeacherId = @TeacherId,LectureHours = @LectureHours," +
                    $"PracticeHours = @PracticeHours, UpdatedAt  = @UpdatedAt WHERE id={Id};";
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

