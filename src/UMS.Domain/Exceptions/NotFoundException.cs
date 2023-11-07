namespace UMS.Domain.Exceptions;

public class NotFoundException : Exception
{
    public string ExceptionMessage { get; set; } = string.Empty;
}
