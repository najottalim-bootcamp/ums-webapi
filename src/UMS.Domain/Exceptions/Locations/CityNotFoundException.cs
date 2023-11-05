namespace UMS.Domain.Exceptions.Locations;

public class CityNotFoundException :NotFoundException
{
    public CityNotFoundException()
    {
        ExceptionMessage = "City not found !";
    }
}
