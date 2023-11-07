namespace UMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpetialtyEduFormController : ControllerBase
    {
        private readonly ISpecialtyEduFormService _specialtyEduFormService;

        public SpetialtyEduFormController(ISpecialtyEduFormService specialtyEduFormService)
        {
            _specialtyEduFormService = specialtyEduFormService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] SpecialtyEduFormDTO specialtyEduFormDTO)
        {
            bool result = await _specialtyEduFormService.CreateAsync(specialtyEduFormDTO);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _specialtyEduFormService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] SpecialtyEduFormDTO specialtyEduFormDTO)
        {
            bool result = await _specialtyEduFormService.UpdateAsync(id, specialtyEduFormDTO);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var result = await _specialtyEduFormService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            bool result = await _specialtyEduFormService.DeleteAsync(id);

            return Ok(result);
        }

    }
}
