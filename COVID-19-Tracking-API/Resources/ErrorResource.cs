using System;
using System.Collections.Generic;

namespace C19Tracking.API.Resources
{
    public enum ErrorCode
    {
        Unknown = -1,
        UnAuthorized = 0,


    }
    public class ErrorResource
    { 
        public ErrorCode ErrorCode = ErrorCode.Unknown;
        public List<string> Messages { get; private set; }

        public ErrorResource(List<string> messages, ErrorCode errorCode = ErrorCode.Unknown )
        {
            this.Messages = messages ?? new List<string>();
        }

        public ErrorResource(string message, ErrorCode errorCode = ErrorCode.Unknown)
        {
            this.Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Messages.Add(message);
            }
        }
    }
}