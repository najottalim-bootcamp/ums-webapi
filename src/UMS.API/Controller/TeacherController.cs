namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacher;

        public TeacherController(ITeacherService teacher)
        {
            _teacher = teacher;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] TeacherDTO dto)
        {
            var result = await _teacher.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var teachers = await _teacher.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(long Id)
        {
            var result = await _teacher.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long Id, [FromForm] TeacherDTO dto)
        {
            var result = _teacher.UpdateAsync(Id, dto);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long Id)
        {
            var result = _teacher.DeleteAsync(Id);
            return Ok(result);
        }
    }
}
