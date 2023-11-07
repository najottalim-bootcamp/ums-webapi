namespace UMS.Service.Dtos.PersonalDatas
{
    public class PersonalDataDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        [Email]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
    }
}
