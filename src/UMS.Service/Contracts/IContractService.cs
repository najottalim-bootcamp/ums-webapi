namespace UMS.Service.Contracts
{
	public interface IContractService
	{
		public ValueTask<bool> CreateAsync(ContractDto contractDto);
		public ValueTask<bool> UpdateAsync(long id,ContractDto contractDto);
		public ValueTask<bool> DeleteAsync(long id);
		public ValueTask<Contract> GetByIdAsync(long id);
		public ValueTask<IList<Contract>> GetAllAsync();
	}
}

