    namespace UMS.DataAccess.Repositories.Students
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        //Check it
        public async ValueTask<int> CreateAsync(Student model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"INSERT INTO Students(PersonalDataId,Course,SpecialtyEduFormId,IsActive,EduType,GroupNumber,SubjectId,Created_At)
                                            VAlUES(@PersonalDataId,@Course,@SpecialtyEduFormId,@IsActive,@EduType,@GroupNumber,@SubjectId,@CreatedAt);";

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

                string query = "DELETE FROM Students WHERE Id = @Id;";
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

        public async ValueTask<IList<Student>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Students;";
                var students = (await _connection.QueryAsync<Student>(query)).ToList();
                return students;
            }
            catch
            {
                return new List<Student>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Student> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Students WHERE Id = @Id";
                var student = await _connection.QueryFirstOrDefaultAsync<Student>(query, new { Id = Id });

                return student;
            }
            catch
            {
                return new Student();
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

                string query = "SELECT COUNT(*) FROM Students;";
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

        public async ValueTask<IList<Student>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM Students ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var students = (await _connection.QueryAsync<Student>(query)).ToList();
                return students;
            }
            catch
            {
                return new List<Student>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
        //Check it
        public async ValueTask<int> UpdateAsync(long Id, Student model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @$"UPDATE Students SET PersonalDataId=@PersonalDataId,Course=@Course,SpecialtyEduFormId=@SpecialtyEduFormId,
                                                        IsActive=@IsActive,EduType=@EduType,GroupNumber=@GroupNumber,SubjectId=@SubjectId,Updated_At=@UpdatedAt
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
