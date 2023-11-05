using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Common.Paginations;
using UMS.DataAccess.Dtos.Cities;
using UMS.DataAccess.Dtos.Contracts;
using UMS.DataAccess.Dtos.Students;
using UMS.DataAccess.Dtos.Subjects;
using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.Contracts;
using UMS.DataAccess.Repositories.Students;
using UMS.DataAccess.Repositories.Subjects;
using UMS.Domain.Entities.EduModels;
using UMS.Domain.Entities.Locations;
using UMS.Domain.Entities.Payments;
using UMS.Domain.Entities.Students;

namespace UMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISubjectRepository _repository;

        public TestController(ISubjectRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] SubjectDto dto)
        {
            Subject subject = new Subject()
            {
                Name = dto.Name,
                SpecialtyId = dto.SpecialtyId,
                CreatedAt = DateTime.Now,
            };



            int result = await _repository.CreateAsync(subject);

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
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] SubjectDto dto)
        {
            Subject subject = new Subject()
            {
                Name = dto.Name,
                SpecialtyId = dto.SpecialtyId,
                UpdatedAt = DateTime.Now,
            };

            var res = await _repository.UpdateAsync(id, subject);
            return Ok(res);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            var res = await _repository.DeleteAsync(id);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPageItems([FromForm] int pageNumber, int pageSize)
        {
            var res = await _repository.GetPageItems(new PaginationParams(pageNumber, pageSize));
            return Ok(res);
        }
    }
}
