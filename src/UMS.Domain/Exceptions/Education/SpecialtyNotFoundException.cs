namespace UMS.Domain.Exceptions.Education;

public class SpecialtyNotFoundException : NotFoundException 
{
    public SpecialtyNotFoundException()
    {
        ExceptionMessage = "Specialty not found !";
    }
}
