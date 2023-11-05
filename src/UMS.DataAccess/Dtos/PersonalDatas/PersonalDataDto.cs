using static UMS.Domain.Enums.GenderEnum;

namespace UMS.DataAccess.Dtos.PersonalDatas
{
    public class PersonalDataDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
    }
}
