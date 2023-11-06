using Microsoft.AspNetCore.Mvc;
using UMS.Service.Cities;
using UMS.Service.Dtos.Cities;

namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _personal;

        public CityController(ICityService personal)
        {
            _personal = personal;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CityDto dto)
        {


            bool result = await _personal.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var cities = await _personal.GetAllAsync();

            return Ok(cities);
        }

        [HttpGet("get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var city = await _personal.GetByIdAsync(id);

            return Ok(city);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] CityDto dto)
        {


            bool res = await _personal.UpdateAsync(id, dto);
            return Ok(res);
        }


    }
}
