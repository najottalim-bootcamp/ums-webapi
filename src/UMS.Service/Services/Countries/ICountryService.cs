using UMS.Service.Dtos.Countries;

namespace UMS.Service.Countries
{
    public interface ICountryService
    {
        public Task<bool> CreateAsync(CountryDto dto);
        public Task<IList<Country>> GetAllAsync();
        public Task<Country> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(long conId, CountryDto dto);
        

    }
}
