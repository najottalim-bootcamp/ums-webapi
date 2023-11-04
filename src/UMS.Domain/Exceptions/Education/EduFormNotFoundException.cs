namespace UMS.Domain.Exceptions.Education;

public class EduFormNotFoundException : NotFoundException
{
    public EduFormNotFoundException()
    {
        ExceptionMessage = "Edu form not found !";
    }
}
