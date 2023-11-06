namespace UMS.Domain.Exceptions.Education;

public class FacultyNotFoundException : NotFoundException
{
    public FacultyNotFoundException()
    {
        ExceptionMessage = "Faculty not found !";
    }
}
