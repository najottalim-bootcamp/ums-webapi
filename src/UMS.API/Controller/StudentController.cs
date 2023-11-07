namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] StudentDto studentDto)
        {
            bool result = await _studentService.CreateAsync(studentDto);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _studentService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] StudentDto studentDto)
        {
            bool result = await _studentService.UpdateAsync(id, studentDto);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var result = await _studentService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            bool result = await _studentService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
