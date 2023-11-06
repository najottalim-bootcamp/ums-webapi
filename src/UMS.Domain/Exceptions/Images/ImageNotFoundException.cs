namespace UMS.Domain.Exceptions.Images;

public class ImageNotFoundException : NotFoundException
{
    public ImageNotFoundException()
    {
        ExceptionMessage = "Image not found !";
    }
}
