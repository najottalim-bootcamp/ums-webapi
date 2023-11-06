using Microsoft.AspNetCore.Mvc;
using UMS.Service.Contracts;
using UMS.Service.Dtos.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMS.API.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] ContractDto contractDto)
        {
            bool result = await _contractService.CreateAsync(contractDto);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var contracts = _contractService.GetAllAsync();
            return Ok(contracts);
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var contract = _contractService.GetByIdAsync(id);
            return Ok(contract);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id ,[FromForm] ContractDto contractDto)
        {
            bool result = await _contractService.UpdateAsync(id,contractDto);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            bool result = await _contractService.DeleteAsync(id);
            return Ok(result);
        }

    }
}

