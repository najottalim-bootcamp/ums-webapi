namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly FacultyService faculty;

        public FacultyController(FacultyService _faculty)
        {
            faculty = _faculty;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] FacultyDto dto)
        {
            var result = await faculty.CreateAsync(dto);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var faculties = await faculty.GetAllAsync();

            return Ok(faculties);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(long Id)
        {
            var result = await faculty.GetByIdAsync(Id);

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long Id, [FromForm] FacultyDto dto)
        {
            var result = await faculty.UpdateAsync(Id, dto);

            return Ok(result);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long Id)
        {
            var result = await faculty.DeleteAsync(Id);

            return Ok(result);
        }

    }
}
