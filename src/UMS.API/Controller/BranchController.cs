namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branch;

        public BranchController(IBranchService _branch)
        {
            branch = _branch;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] BranchDto dto)
        {
            bool result = await branch.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await branch.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(long Id)
        {
            var result = await branch.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long Id, [FromForm] BranchDto dto)
        {
            bool result = await branch.UpdateAsync(Id, dto);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long Id)
        {
            bool res = await branch.DeleteAsync(Id);
            return Ok(res);
        }
    }
}
