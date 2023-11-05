using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Common.Paginations;
using UMS.DataAccess.Dtos.Education;
using UMS.DataAccess.Repositories.Departments;
using UMS.DataAccess.Repositories.Faculties;
using UMS.Domain.Entities.EduModels;

namespace UMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        public TestController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] DepartmentDto dto)
        {
            Department city = new Department(); 
            city.Name = dto.Name;
            city.FacultyID = dto.FacultyID;

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
        public async ValueTask<IActionResult> UpdateAsync( long id, [FromForm] DepartmentDto dto)
        {
            Department city = new Department();
            city.Name = dto.Name;
            city.FacultyID = dto.FacultyID;

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
