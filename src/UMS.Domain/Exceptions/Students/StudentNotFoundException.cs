namespace UMS.Domain.Exceptions.Students;

public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException()
    {
        ExceptionMessage = "Student not found !";
    }
}
