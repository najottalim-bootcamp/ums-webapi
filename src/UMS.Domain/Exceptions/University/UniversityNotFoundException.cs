namespace UMS.Domain.Exceptions.University;

public class UniversityNotFoundException : NotFoundException
{
    public UniversityNotFoundException()
    {
        ExceptionMessage = "University not found !";
    }
}
