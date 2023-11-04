using System;
using UMS.DataAccess.Dtos.University;
using UMS.Domain.Entities.University;

namespace UMS.DataAccess.Repositories.Universities
{
    public class UniversityRepository : BaseRepository, IUniversityRepository
    {
        public async ValueTask<int> CreateAsync(UniversityDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO University VALUES(@Name, @Description, @ImagePath)";
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

                string query = "DELETE FROM University WHERE Id=@Id";
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

        public async ValueTask<IList<University>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM University";
                var result = (await _connection.QueryAsync<University>(query)).ToList();
                           
                return result;
            }
            catch
            {
                return new List<University>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<University> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM University where Id = @Id;";
                var result = (await _connection.QueryFirstOrDefaultAsync<University>(query, new { Id = Id }));
                return result;
            }
            catch
            {
                return new University();
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

                string query = "SELECT COUNT(*) FROM University;";
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

        public async ValueTask<IList<University>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM University ORDER BY Id DESC " +
                                  $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";
                var result = (await _connection.QueryAsync<University>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<University>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, UniversityDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "UPDATE University SET Name = @Name,Description=@Description,ImagePath=@ImagePath;";
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

