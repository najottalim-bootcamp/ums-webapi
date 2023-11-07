using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.Service.Dtos.Teachers;
using UMS.Service.Services.Teachers;

namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacher;

        public TeacherController(ITeacherService _teacher)
        {
            teacher = _teacher; 
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(TeacherDTO dto)
        {
            var result = await teacher.CreateAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var teachers = await teacher.GetAllAsync();

            return Ok(teachers);
        }

        public async ValueTask<IActionResult> GetByIdAsync(long Id)
        {
            var result = await teacher.GetByIdAsync(Id);

            return Ok(result);
        }

        public async ValueTask<IActionResult> UpdateAsync(long Id ,[FromForm] TeacherDTO dto)
        {
            var result = teacher.UpdateAsync(Id, dto); 

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long Id)
        {
            var result = teacher.DeleteAsync(Id);

            return Ok(result);
        }


    }
}
