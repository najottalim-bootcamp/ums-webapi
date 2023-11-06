using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Dtos.Cities;
using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.PersonalDatas;
using UMS.Domain.Entities.Locations;

namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _personal;

        public CityController(ICityRepository personal)
        {
            _personal = personal;
        }


        public async ValueTask<IActionResult> CreateAsync([FromForm] CityDto dto)
        {
            City city = new City();
            city.Name = dto.Name;
            city.CreatedAt = DateTime.Now;

            int result = await _personal.CreateAsync(city);
            return Ok(result);
        }

        public async ValueTask<IActionResult> GetAllAsync()
        {
            var cities = await _personal.GetAllAsync();

            return Ok(cities);
        }

        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var city = await _personal.GetByIdAsync(id);

            return Ok(city);
        }

        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] CityDto dto)
        {
            City city = new City()
            {
                Name = dto.Name,
                UpdatedAt = DateTime.Now,
            };

            var res = await _personal.UpdateAsync(id, city);
            return Ok(res);
        }


    }
}
