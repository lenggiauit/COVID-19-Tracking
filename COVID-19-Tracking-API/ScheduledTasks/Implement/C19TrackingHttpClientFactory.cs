using C19Tracking.Domain.Helpers;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace C19Tracking.ScheduledTasks.Implement
{
    public class C19TrackingHttpClientFactory : IC19TrackingHttpClientFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly APIDataSettings _apiDataSettings;
        private readonly ILogger<C19TrackingHttpClientFactory> _logger;
        public C19TrackingHttpClientFactory(IHttpClientFactory clientFactory, ILogger<C19TrackingHttpClientFactory> logger, IOptions<APIDataSettings> apiDataSettings)
        {
            _clientFactory = clientFactory;
            _apiDataSettings = apiDataSettings.Value;
            _logger = logger;
        }
        public async Task<JsonContent> SendAsync(string apiKey, Dictionary<string, string> headers)
        {
            var apiOption = _apiDataSettings.ListAPIOptions.Where(c => c.Name.Equals(apiKey)).FirstOrDefault();
            if(apiOption != null)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, apiOption.Url);
                request.Headers.Add("Accept", "application/json");
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key , header.Value);
                }
                
                var client = _clientFactory.CreateClient(); 
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (response.IsSuccessStatusCode)
                { 
                    try
                    {
                        return await response.Content.ReadFromJsonAsync<JsonContent>();
                    }
                    catch (NotSupportedException)  
                    {
                        _logger.LogError("The content type is not supported.");
                    }
                    catch (JsonException)  
                    {
                        _logger.LogError("Invalid JSON.");
                    }
                    return null;
                } 
            }
            return null;
        }
        public async Task PostJsonHttpClient(string apiKey, object value)
        {
            var apiOption = _apiDataSettings.ListAPIOptions.Where(c => c.Name.Equals(apiKey)).FirstOrDefault();
            if (apiOption != null)
            {
                var client = _clientFactory.CreateClient();
                var postResponse = await client.PostAsJsonAsync(apiOption.Url, value); 
                postResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
