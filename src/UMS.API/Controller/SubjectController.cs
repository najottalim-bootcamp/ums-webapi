using Microsoft.AspNetCore.Mvc;
using UMS.Service.Dtos.Subjects;
using UMS.Service.Subjects;

namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm]SubjectDto subjectDto)
        {
            bool result = await _subjectService.CreateAsync(subjectDto);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var subjects = await _subjectService.GetAllAsync();

            return Ok(subjects);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var subject = await _subjectService.GetByIdAsync(id);

            return Ok(subject);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id , [FromForm] SubjectDto subjectDto)
        {
            bool result = await _subjectService.UpdateAsync(id,subjectDto);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            bool result = await _subjectService.DeleteAsync(id);
            return Ok(result);
        }


    }
}

