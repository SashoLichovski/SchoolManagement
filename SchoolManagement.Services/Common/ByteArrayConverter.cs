using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Common
{
    public static class ByteArrayConverter
    {
        public async static Task<byte[]> ConvertImageToByteArrayAsync(List<IFormFile> userImage)
        {
            MemoryStream stream = new MemoryStream();
            foreach (var item in userImage)
            {
                await item.CopyToAsync(stream);
            }
            return stream.ToArray();
        }
    }
}
