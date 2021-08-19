using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace C19Tracking.API.Domain.Helpers
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file, string path);
    }
}
