namespace UMS.Domain.Exceptions.Teachers;

public class ScianDegreeNotFoundException : NotFoundException
{
    public ScianDegreeNotFoundException()
    {
        ExceptionMessage = "Scien degree not found !";
    }
}
