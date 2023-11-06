using Microsoft.AspNetCore.Http;
using static UMS.Domain.Enums.GenderEnum;

namespace UMS.Service.ViewModels.Students;

public class StudentViewModel
{
    public long StudentId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public bool IsActive { get; set; }
    public string EduType { get; set; }
    public string GroupNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public string UserAvatar { get; set; } = default!;
}
