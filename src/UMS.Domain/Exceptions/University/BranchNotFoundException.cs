namespace UMS.Domain.Exceptions.University;

public class BranchNotFoundException : NotFoundException
{
    public BranchNotFoundException()
    {
        ExceptionMessage = "Branch not found !";
    }
}
