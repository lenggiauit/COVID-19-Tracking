using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 

namespace C19Tracking.API.Domain.Helpers
{
    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file, string path)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file, path);
            }
            return string.Empty;
        }
         
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }
         
        public async Task<string> WriteFile(IFormFile file, string filePath)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; 
                var path = Path.Combine(filePath, fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }
    }
}