namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] UniversityDto universityDto)
        {
            bool result = await _universityService.CreateAsync(universityDto);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var universities = _universityService.GetAllAsync();
            return Ok(universities);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var university = _universityService.GetByIdAsync(id);
            return Ok(university);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] UniversityDto universityDto)
        {
            bool result = await _universityService.UpdateAsync(id,universityDto);
            return Ok(result);
        }
    }
}

