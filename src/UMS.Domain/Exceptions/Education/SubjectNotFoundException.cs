namespace UMS.Domain.Exceptions.Education;

public class SubjectNotFoundException : NotFoundException
{
    public SubjectNotFoundException()
    {
        ExceptionMessage = "Subject not found !";
    }
}

