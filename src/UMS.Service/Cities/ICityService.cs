using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.Cities;
using UMS.DataAccess.Dtos.Countries;
using UMS.Domain.Entities.Locations;

namespace UMS.Service.Cities
{
    public interface ICityService
    {
        public Task<bool> CreateAsync(CityDto dto);
        public Task<IList<City>> GetAllAsync();
        public Task<City> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(long conId, City dto);
    }
}
