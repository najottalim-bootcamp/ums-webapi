using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Common.Paginations;
using UMS.DataAccess.Dtos.Cities;
using UMS.DataAccess.Dtos.Teachers;
using UMS.DataAccess.Repositories.AcadPositions;
using UMS.DataAccess.Repositories.Cities;
using UMS.Domain.Entities.Locations;

namespace UMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICityRepository _repository;

        public TestController(ICityRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CityDto dto)
        {
            City city = new City(); 
            city.Name = dto.Name;
            city.CreatedAt = DateTime.Now;

            int result = await _repository.CreateAsync(city);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync([FromQuery] long id) 
        {
            var res = await _repository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _repository.GetAllAsync();
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync( long id, [FromForm] CityDto dto)
        {
            City  city =  new City();

            city.Name = dto.Name;
            city.UpdatedAt  = DateTime.Now;

            var res = await _repository.UpdateAsync(id, city);
            return Ok(res);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            var res = await _repository.DeleteAsync(id);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPageItems([FromForm] int pageNumber, int  pageSize)
        {
            var res = await _repository.GetPageItems(new PaginationParams(pageNumber, pageSize));
            return Ok(res);
        }
    }
}
