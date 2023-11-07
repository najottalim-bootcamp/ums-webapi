namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService speciltyService)
        {
            _specialtyService = speciltyService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] SpecialtyDTO specialtyDTO)
        {
            bool result = await _specialtyService.CreateAsync(specialtyDTO);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var specialties = await _specialtyService.GetAllAsync();
            return Ok(specialties);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var specialty = await _specialtyService.GetByIdAsync(id);
            return Ok(specialty);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            bool result = await _specialtyService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

