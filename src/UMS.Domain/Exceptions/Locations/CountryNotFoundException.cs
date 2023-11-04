namespace UMS.Domain.Exceptions.Locations;

public class CountryNotFoundException : NotFoundException
{
    public CountryNotFoundException()
    {
        ExceptionMessage = "Country not found !";
    }
}
