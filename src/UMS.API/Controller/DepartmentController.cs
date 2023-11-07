using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.Service.Departments;
using UMS.Service.Dtos.Education;

namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService department;

        public DepartmentController(IDepartmentService _department)
        {
            department = _department;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] DepartmentDto dto)
        {
            bool result = await department.CreateAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await department.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(long Id)
        {
            var result = await department.GetByIdAsync(Id);

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long Id, [FromForm] DepartmentDto dto)
        {
            var result = await department.UpdateAsync(Id, dto);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long Id)
        {
            var result = await department.DeleteAsync(Id);

            return Ok(result);
        }

    }
}
