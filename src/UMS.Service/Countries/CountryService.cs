using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.Countries;
using UMS.Domain.Entities.EduModels;

namespace UMS.Service.Countries
{
    public class CountryService : ICountryService
    {


        public CountryService()
        {
            
        }

        public Task<bool> CreateAsync(CountryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Faculty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Faculty>> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long conId, CountryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
