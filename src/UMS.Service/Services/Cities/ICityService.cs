using UMS.Service.Dtos.Cities;

namespace UMS.Service.Cities
{
    public interface ICityService
    {
        public Task<bool> CreateAsync(CityDto dto);
        public Task<IList<City>> GetAllAsync();
        public Task<City> GetByIdAsync(long id);
        public Task<bool> UpdateAsync(long conId, CityDto dto);
    }
}
