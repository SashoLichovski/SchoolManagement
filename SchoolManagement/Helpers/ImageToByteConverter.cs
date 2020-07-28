using System;
using System.IO;

namespace SchoolManagement.Helpers
{
    public static class ImageToByteConverter
    {
        internal static byte[] Convert(string userImage)
        {
            FileStream fileStream = new FileStream(userImage, FileMode.Open);
            byte[] image = new byte[fileStream.Length];
            fileStream.Read(image, 0, (int)fileStream.Length);
            fileStream.Close();
            return image;
        }
    }
}
