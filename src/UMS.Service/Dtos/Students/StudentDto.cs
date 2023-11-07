namespace UMS.Service.Dtos.Students
{
    public class StudentDto
    {
        public long PersonalDataId { get; set; }
        public int Course { get; set; }
        public long SpecialtyEduFormId { get; set; }
        public bool IsActive { get; set; }
        public string EduType { get; set; }
        public string GroupNumber { get; set; }
        public long SubjectId { get; set; }
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
        public IFormFile UserAvatar { get; set; } = default!;

    }
}
