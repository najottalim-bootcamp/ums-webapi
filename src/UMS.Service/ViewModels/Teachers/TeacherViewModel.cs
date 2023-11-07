using Microsoft.AspNetCore.Http;
using System.Globalization;
using static UMS.Domain.Enums.GenderEnum;
using static UMS.Domain.Enums.PositionEnum;

namespace UMS.Service.ViewModels.Teachers;

public class TeacherViewModel
{
    public long TeacherId { get; set; } 
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public Position Position { get; set; }
    public string ScienDegree { get; set; }
    public string Deparment { get; set; }
    public string PhoneNumber { get; set; }
    public string UserAvatar { get; set; } = default!;
}
