using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C19Tracking.API.Domain.Helpers
{
    public interface IImageHandler
    {
        Task<string> UploadImage(IFormFile file, string path);
    }

    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<string> UploadImage(IFormFile file, string path)
        { 
            return await _imageWriter.UploadImage(file, path);
        }
    }
}
