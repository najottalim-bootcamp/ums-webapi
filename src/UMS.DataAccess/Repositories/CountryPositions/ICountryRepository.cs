using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.Countries;
using UMS.Domain.Entities.Locations;

namespace UMS.DataAccess.Repositories.CountryPositions
{
    internal interface ICountryRepository:IBaseRepository<Country,CountryDto>
    {
    }
}
