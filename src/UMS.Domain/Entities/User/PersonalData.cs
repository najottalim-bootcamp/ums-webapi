using static UMS.Domain.Enums.GenderEnum;

namespace UMS.Domain.Entities.People
{
    public class PersonalData : Auditable
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
    }
}
