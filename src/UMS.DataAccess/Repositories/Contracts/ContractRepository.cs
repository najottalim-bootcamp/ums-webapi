namespace UMS.DataAccess.Repositories.Contracts
{
    public class ContractRepository : BaseRepository, IContractRepository
    {
        //Check it
        public async ValueTask<int> CreateAsync(ContractDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"INSERT INTO Contract(FacultId,StudentId,Price,CreatedAt)
                                            VAlUES(@FacultId,@StudentId,@Price,@CreatedAt);";

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

                string query = "DELETE FROM Contract WHERE Id = @Id;";
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

        public async ValueTask<IList<Contract>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM Contract;";
                var result = (await _connection.QueryAsync<Contract>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Contract>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Contract> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM Contract WHERE Id = @Id";
                var result = await _connection.QueryFirstOrDefaultAsync<Contract>(query, new { Id = Id });

                return result;
            }
            catch
            {
                return new Contract();
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

                string query = "SELECT COUNT(*) FROM Contract;";
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

        public async ValueTask<IList<Contract>> GetPageItems(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM Contract ORDER BY Id DESC " +
                    $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

                var result = (await _connection.QueryAsync<Contract>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Contract>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
        //Check it
        public async ValueTask<int> UpdateAsync(long Id, ContractDto model)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @$"UPDATE Contract SET FacultId=@FacultId,StudentId=@StudentId,Price=@Price,UpdatedAt=@UpdatedAt 
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
