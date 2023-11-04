namespace UMS.Domain.Exceptions.Teachers;

public class AcadPositionNotFoundException : NotFoundException
{
    public AcadPositionNotFoundException()
    {
        ExceptionMessage = "Acad position not found !";
    }
}
