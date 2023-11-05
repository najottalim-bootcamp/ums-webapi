namespace UMS.Domain.Exceptions.Payments;

public class ContractNotFoundException : NotFoundException
{
    public ContractNotFoundException() 
    {
        ExceptionMessage = "Contract not found !";
    }
}
