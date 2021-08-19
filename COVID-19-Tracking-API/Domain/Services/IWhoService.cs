using C19Tracking.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Services
{
    public interface IWhoService
    {
        Task GetData(string request);
    }
}
