namespace UMS.DataAccess.Repositories.Subjects
{
    public class SubjectRepository : BaseRepository, ISubjectRepository
    {
        //Check it
        public async ValueTask<int> CreateAsync(SubjectDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"INSERT INTO Subjects(Name,SpecialityId,CreatedAt)
                                            VAlUES(@Name,@SpecialityId,@CreatedAt);";

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

                string query = "DELETE FROM Subjects WHERE Id = @Id;";
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

        public async ValueTask<IList<Subject>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Subjects;";
                var subjects = (await _connection.QueryAsync<Subject>(query)).ToList();
                return subjects;
            }
            catch
            {
                return new List<Subject>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Subject> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Subjects WHERE Id = @Id";
                var subjects = await _connection.QueryFirstOrDefaultAsync<Subject>(query, new { Id = Id });

                return subjects;
            }
            catch
            {
                return new Subject();
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

                string query = "SELECT COUNT(*) FROM Subjects;";
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

        public async ValueTask<IList<Subject>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM Subjects ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var subjects = (await _connection.QueryAsync<Subject>(query)).ToList();
                return subjects;
            }
            catch
            {
                return new List<Subject>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
        //Check it
        public async ValueTask<int> UpdateAsync(long Id, SubjectDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @$"UPDATE Subjects SET Name=@Name,SpecialityId=@SpecialityId,UpdatedAt=@UpdatedAt 
                                    WHERE id={Id};";
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
