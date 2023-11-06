namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(StudentDto studentDto)
        {
            bool result = await _service.CreateAsync(studentDto);
            return Ok(result);
        }
    }
}
