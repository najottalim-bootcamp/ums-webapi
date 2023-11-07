namespace UMS.Service.Dtos.University;

public class UniversityDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile ImagePath { get; set; } = default!;
}


