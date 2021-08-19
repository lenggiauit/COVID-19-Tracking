using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Services.Communication.Response
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Messages { get; private set; }
        public T Resource { get; private set; }

        protected BaseResponse(T resource)
        {
            Success = true;
            Messages = string.Empty;
            Resource = resource;
        } 
        protected BaseResponse(string message)
        {
            Success = false;
            Messages = message;
            Resource = default;
        }
        protected BaseResponse(bool success)
        {
            Success = success;
            Messages = string.Empty;
            Resource = default;
        }
    }
}
