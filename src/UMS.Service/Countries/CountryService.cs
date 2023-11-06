using UMS.DataAccess.Dtos.Contracts;
using UMS.DataAccess.Dtos.Countries;
using UMS.DataAccess.Repositories.Countries;
using UMS.Domain.Entities.Locations;
using UMS.Domain.Exceptions.Locations;

namespace UMS.Service.Countries
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary> Assinxron qo'shish
        /// 
        /// </summary>
        /// <param name="kiruvchi parametrlar"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<bool> CreateAsync(CountryDto dto)
        {
            Country country = new Country()
            {
                Name = dto.Name,
                CreatedAt = DateTime.Now,
            };


            int result = await _countryRepository.CreateAsync(country);

            return result != 0;
        }

        /// <summary>
        /// Assinxron jadvalni o'qish
        /// </summary>
        /// <returns></returns>

        public async Task<IList<Country>> GetAllAsync()
        {
            IList<Country> countries = await _countryRepository.GetAllAsync();
            return countries;
        }

        /// <summary>
        /// Assinxron obyektni o'qish
        /// </summary>
        /// <param name="id"></param> shu Id bo'yicha
        /// <returns>Country turida obyekt qaytadi</returns>
        /// <exception cref="CountryNotFoundException"></exception>

        public async Task<Country> GetByIdAsync(long id)
        {
            Country country = await _countryRepository.GetByIdAsync(id);
            if (country is null) throw new CountryNotFoundException();

            return country;
        }

        /// <summary>
        /// Assinxron o'zgartirish
        /// </summary>
        /// <param name="conId"></param> shu id ga teng obyektni 
        /// <param name="dto"></param> shu obyektdagi qiymatlarga almashtiradi
        /// <returns>almashtirilsa 1 aks holda 0 qaytariladi</returns>
        /// <exception cref="CountryNotFoundException"></exception>
        public async Task<bool> UpdateAsync(long conId, CountryDto dto)
        {
            Country country = await _countryRepository.GetByIdAsync(conId);
            if (country is null) throw new CountryNotFoundException();

            country.UpdatedAt = DateTime.Now;
            country.Name = dto.Name;


            int result = await _countryRepository.UpdateAsync(conId,country);

            return result > 0;
        }

       
    }
}
    