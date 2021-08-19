using C19Tracking.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Interface
{
    public interface IC19TrackingHttpClientFactory
    {
        Task<JsonContent> SendAsync(string apiKey, Dictionary<string, string> headers);
        Task PostJsonHttpClient(string apiKey, object value);
    }
}
