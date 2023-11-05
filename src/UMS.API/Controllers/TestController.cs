using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Common.Paginations;
using UMS.DataAccess.Dtos.Cities;
using UMS.DataAccess.Dtos.Education;
using UMS.DataAccess.Dtos.Teachers;
using UMS.DataAccess.Repositories.AcadPositions;
using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.ScienDegrees;
using UMS.DataAccess.Repositories.Specialties;
using UMS.DataAccess.Repositories.SpecialtyEduForms;
using UMS.DataAccess.Repositories.Teachers;
using UMS.Domain.Entities.EduModels;
using UMS.Domain.Entities.Locations;
using UMS.Domain.Entities.Teacher;

namespace UMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TestController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] TeacherDTO dto)
        {
            Teacher city = new Teacher(); 
            city.ScienDegreeId = dto.ScienDegreeId;
            city.AcadPositionId = dto.AcadPositionId;
            city.PersonalDataId = dto.PersonalDataId;
            city.DepartmentId = dto.DepartmentId;

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
        public async ValueTask<IActionResult> UpdateAsync( long id, [FromForm] Teacher dto)
        {

            Teacher city = new Teacher();
            city.ScienDegreeId = dto.ScienDegreeId;
            city.AcadPositionId = dto.AcadPositionId;
            city.PersonalDataId = dto.PersonalDataId;
            city.DepartmentId = dto.DepartmentId;

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
