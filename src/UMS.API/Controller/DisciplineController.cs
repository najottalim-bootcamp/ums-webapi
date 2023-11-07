namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] DisciplineDto disciplineDto)
        {
            bool result = await _disciplineService.CreateAsync(disciplineDto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _disciplineService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] DisciplineDto disciplineDto)
        {
            bool result = await _disciplineService.UpdateAsync(id, disciplineDto);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var result = await _disciplineService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            bool result = await _disciplineService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
