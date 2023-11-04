namespace UMS.Domain.Exceptions.Teachers;

public class TeacherNotFoundException : NotFoundException 
{
    public TeacherNotFoundException()
    {
        ExceptionMessage = "Teacher not found !";
    }
}
