using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.University;
using UMS.Domain.Entities.University;

namespace UMS.Service.Branches
{
    public interface IBranchService
    {
        public ValueTask<bool> CreateAsync(BranchDto dto);
        public ValueTask<bool> UpdateAsync(long id, BranchDto dto);
        public ValueTask<bool> DeleteAsync(long id);
        public ValueTask<Branch> GetByIdAsync(long id);
        public ValueTask<IList<Branch>> GetAllAsync();
    }
}
