using UMS.DataAccess.Dtos.Contracts;
using UMS.DataAccess.Repositories.Contracts;
using UMS.Domain.Entities.Payments;
using UMS.Domain.Exceptions.Payments;

namespace UMS.Service.Contracts
{

    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async ValueTask<bool> CreateAsync(ContractDto contractDto)
        {
            Contract contract = new Contract()
            {
                FacultId = contractDto.FacultId,
                StudentId = contractDto.StudentId,
                Price=contractDto.Price,
            };

            int result=await _contractRepository.CreateAsync(contract);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract is null) throw new ContractNotFoundException();

            int result=await _contractRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<Contract>> GetAllAsync()
        {
            IList<Contract> contracts = await _contractRepository.GetAllAsync();
            return contracts;
        }

        public async ValueTask<Contract> GetByIdAsync(long id)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract is null) throw new ContractNotFoundException();

            return contract;
        }

        public async ValueTask<bool> UpdateAsync(long id, ContractDto contractDto)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract is null) throw new ContractNotFoundException();

            contract.FacultId = contractDto.FacultId;
            contract.StudentId = contractDto.StudentId;
            contract.Price = contractDto.Price;
            contract.UpdatedAt = DateTime.Now;

            int result = await _contractRepository.UpdateAsync(id,contract);

            return result > 0;
        }
    }
}

