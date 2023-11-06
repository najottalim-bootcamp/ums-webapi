using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.DataAccess.Dtos.Cities;
using UMS.DataAccess.Repositories;
using UMS.DataAccess.Repositories.Cities;
using UMS.Domain.Entities.Locations;
using UMS.Domain.Exceptions.Locations;

namespace UMS.Service.Cities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<bool> CreateAsync(CityDto dto)
        {
            City city = new City()
            {
                Name = dto.Name,
                CreatedAt = DateTime.Now,
            };
            int result = await _cityRepository.CreateAsync(city);

            return result > 0;
        }

        public async Task<IList<City>> GetAllAsync()
        {
            IList<City> cities = await _cityRepository.GetAllAsync();
            return cities;
        }

        public async Task<City> GetByIdAsync(long id)
        {
            City city = await _cityRepository.GetByIdAsync(id);
            if (city is null) throw new CityNotFoundException();

            return city;
        }

        public async Task<bool> UpdateAsync(long conId, CityDto dto)
        {
            City city = await _cityRepository.GetByIdAsync(conId);
            if (city is null) throw new CityNotFoundException();

            city.UpdatedAt = DateTime.Now;
            city.Name = dto.Name;


            int result = await _cityRepository.UpdateAsync(conId, city);

            return result > 0;
        }
    }
}
