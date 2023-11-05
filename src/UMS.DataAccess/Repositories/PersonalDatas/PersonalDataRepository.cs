using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.PersonalDatas;
using UMS.Domain.Entities.People;

namespace UMS.DataAccess.Repositories.PersonalDatas
{
    internal class PersonalDataRepository : BaseRepository, IPersonalDataRepository
    {
        public async ValueTask<int> CreateAsync(PersonalData model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "INSERT INTO PersonalData (FirstName,MiddleName,LastName,CityId,CountryId,Email," +
                    "Gender,PhoneNumber,ImagePath,CreatedAt) VAlUES (@FirstName,@MiddleName,@LastName,@CityId," +
                    "@CountryId,@Email,@Gender,@PhoneNumber,@ImagePath,@CreatedAt);";
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

                string query = "DELETE FROM PersonalData WHERE Id = @Id;";
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

        public async ValueTask<IList<PersonalData>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM PersonalData;";
                var result = (await _connection.QueryAsync<PersonalData>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<PersonalData>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<PersonalData> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM PersonalData WHERE Id = @Id";
                var personal = await _connection.QueryFirstOrDefaultAsync<PersonalData>(query, new { Id = Id });

                return personal;
            }
            catch
            {
                return new PersonalData();
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

                string query = "SELECT COUNT(*) FROM PersonalData;";
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

        public async ValueTask<IList<PersonalData>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM PersonalData ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var personalDatas = (await _connection.QueryAsync<PersonalData>(query)).ToList();
                return personalDatas;
            }
            catch
            {
                return new List<PersonalData>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<int> UpdateAsync(long Id, PersonalData model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE PersonalData SET FirstName = @FirstName,MiddleName = @MiddleName,LastName = @LastName" +
                    $",CityId = @CityId,CountryId = @CountryId,Email = @Email,Gender = @Gender,PhoneNumber = @PhoneNumber,ImagePath = @ImagePath, @UpdatedAt = @UpdatedAt WHERE id={Id};";
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
