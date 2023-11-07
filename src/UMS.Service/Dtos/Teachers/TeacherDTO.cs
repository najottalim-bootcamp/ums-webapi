using Microsoft.AspNetCore.Http;
using static UMS.Domain.Enums.GenderEnum;

namespace UMS.Service.Dtos.Teachers
{
    public class TeacherDTO
    {
        public long DepartmentId { get; set; }
        public long PersonalDataId { get; set; }
        public long AcadPositionId { get; set; }
        public long ScienDegreeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile UserAvatar { get; set; } = default!;
    }
}
