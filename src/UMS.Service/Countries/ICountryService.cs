using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.Countries;
using UMS.DataAccess.Dtos.Education;
using UMS.Domain.Entities.EduModels;

namespace UMS.Service.Countries
{
    public interface ICountryService
    {
        public Task<bool> CreateAsync(CountryDto dto);
        public Task<IList<Faculty>> GetAllAsync();
        public Task<IList<Faculty>> GetById(long id);
        public Task<bool> UpdateAsync(long conId, CountryDto dto);
        

    }
}
