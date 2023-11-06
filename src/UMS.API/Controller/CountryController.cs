using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Dtos.Countries;
using UMS.Service.Countries;

namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService repository;

        public CountryController(ICountryService _repository)
        {
            repository = _repository;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CountryDto dto)
        {

            bool result = await repository.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var countries = await repository.GetAllAsync();

            return Ok(countries);
        }

        [HttpGet("get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var country = await repository.GetByIdAsync(id);

            return Ok(country);
        }
        [HttpPatch]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] CountryDto dto)
        {
            var res = await repository.UpdateAsync(id, dto);
            return Ok(res);
        }


    }
}
