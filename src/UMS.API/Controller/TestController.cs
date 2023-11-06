using Microsoft.AspNetCore.Mvc;
using UMS.DataAccess.Common.Paginations;
using UMS.DataAccess.Dtos.PersonalDatas;
using UMS.DataAccess.Repositories.PersonalDatas;
using UMS.Domain.Entities.People;


namespace UMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPersonalDataRepository _repository;       

        public TestController(IPersonalDataRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] PersonalDataDto dto)
        {
            PersonalData pd = new PersonalData();
            pd.FirstName = dto.FirstName;
            pd.LastName = dto.LastName;
            pd.MiddleName = dto.MiddleName;
            pd.CityId = dto.CityId;
            pd.CountryId = dto.CountryId;
            pd.Email = dto.Email;
            pd.Gender = dto.Gender;
            pd.PhoneNumber = dto.PhoneNumber;
            pd.ImagePath = dto.ImagePath;
            pd.CreatedAt = DateTime.Now;

            int result = await _repository.CreateAsync(pd);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync([FromQuery] long id)
        {
            var res = await _repository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _repository.GetAllAsync();
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(long id, [FromForm] PersonalDataDto dto)
        {
            PersonalData pd = new PersonalData();
            pd.FirstName = dto.FirstName;
            pd.LastName = dto.LastName;
            pd.MiddleName = dto.MiddleName;
            pd.CityId = dto.CityId;
            pd.CountryId = dto.CountryId;
            pd.Email = dto.Email;
            pd.Gender = dto.Gender;
            pd.PhoneNumber = dto.PhoneNumber;
            pd.ImagePath = dto.ImagePath;
            pd.CreatedAt = DateTime.Now;

            var res = await _repository.UpdateAsync(id, pd);
            return Ok(res);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            var res = await _repository.DeleteAsync(id);
            return Ok(res);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPageItems([FromForm] int pageNumber, int pageSize)
        {
            var res = await _repository.GetPageItems(new PaginationParams(pageNumber, pageSize));
            return Ok(res);
        }
    }
}
