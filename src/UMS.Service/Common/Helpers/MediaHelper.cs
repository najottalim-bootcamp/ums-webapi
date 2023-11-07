namespace UMS.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        if (GetImageExtensions().Any(e => e == extension))
        {
            string name = "IMG_" + Guid.NewGuid() + extension;
            return name;
        }
        return "";
    }

    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".bmp",
            ".svg"
        };
    }
}
