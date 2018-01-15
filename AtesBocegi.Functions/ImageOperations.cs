using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace AtesBocegi.Functions
{
    public class ImageOperations
    {
        public static string GetBase64FromFile(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.OpenReadStream().CopyTo(ms);
            string imageBase64Data = Convert.ToBase64String(ms.ToArray());
            string base64String = string.Format("data:image/" + file.ContentType + ";base64,{0}", imageBase64Data);
            return base64String;
        }
    }
}
