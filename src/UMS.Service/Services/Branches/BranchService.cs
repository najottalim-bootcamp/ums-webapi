using UMS.Service.Dtos.University;

namespace UMS.Service.Branches
{
    public class BranchService : IBranchService
    {

        private readonly IBranchRepository _branchRepository;


        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async ValueTask<bool> CreateAsync(BranchDto dto)
        {
            Branch branch = new Branch()
            {
                Name = dto.Name,
                CityID = dto.CityID,
                Address = dto.Address,
                PostCode = dto.PostCode,
                UniversityId = dto.UniversityId
                
            };

            int result = await _branchRepository.CreateAsync(branch);

            return result > 0;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            Branch branch = await _branchRepository.GetByIdAsync(id);
            if (branch is null) throw new BranchNotFoundException();

            int result = await _branchRepository.DeleteAsync(id);

            return result > 0;
        }

        public async ValueTask<IList<Branch>> GetAllAsync()
        {
            IList<Branch> branches = await _branchRepository.GetAllAsync();
            return branches;
        }

        public async ValueTask<Branch> GetByIdAsync(long id)
        {
            Branch branch = await _branchRepository.GetByIdAsync(id);
            if (branch is null) throw new BranchNotFoundException();

            return branch;
        }

        public async ValueTask<bool> UpdateAsync(long id, BranchDto dto)
        {
            Branch branch = await _branchRepository.GetByIdAsync(id);
            if (branch is null) throw new BranchNotFoundException();


            branch.Name = dto.Name;
            branch.CityID = dto.CityID;
            branch.Address = dto.Address;
            branch.PostCode = dto.PostCode;
            branch.UniversityId = dto.UniversityId;




            int result = await _branchRepository.UpdateAsync(id, branch);

            return result > 0;
        }
    }
}
