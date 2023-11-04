namespace UMS.Domain.Exceptions.Education;

public class DepartmentNotFoundException : NotFoundException
{
    public DepartmentNotFoundException()
    {
        ExceptionMessage = "Department not found !";
    }
}
