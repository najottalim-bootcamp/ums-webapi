namespace UMS.DataAccess.Repositories.SpecialtyEduForms
{
    public class SpecialtyEduFormRepository : BaseRepository, ISpecialtyEduFormRepository
    {
        public async ValueTask<int> CreateAsync(SpecialtyEduForm model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO SpecialtyEduForm VALUES(@EduFormId, @SpecialtyId);";
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

                string query = "DELETE FROM SpecialtyEduForm WHERE Id = @Id;";
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

        public async ValueTask<IList<SpecialtyEduForm>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM SpecialtyEduForm;";
                var specialtyEduForms = (await _connection.QueryAsync<SpecialtyEduForm>(query)).ToList();
                return specialtyEduForms;
            }
            catch
            {
                return new List<SpecialtyEduForm>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<SpecialtyEduForm> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM SpecialtyEduForm WHERE Id = @Id";
                var specialtyEduForm = await _connection.QueryFirstOrDefaultAsync<SpecialtyEduForm>(query, new { Id = Id });

                return specialtyEduForm;
            }
            catch
            {
                return new SpecialtyEduForm();
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

                string query = "SELECT COUNT(*) FROM SpecialtyEduForm;";
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

        public async ValueTask<IList<SpecialtyEduForm>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM SpecialtyEduForm ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var specialtyEduForms = (await _connection.QueryAsync<SpecialtyEduForm>(query)).ToList();
                return specialtyEduForms;
            }
            catch
            {
                return new List<SpecialtyEduForm>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, SpecialtyEduForm model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE SpecialtyEduForm SET EduFormId=@EduFormId,  SpecialtyId = @SpecialtyId WHERE id = {Id};";
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
