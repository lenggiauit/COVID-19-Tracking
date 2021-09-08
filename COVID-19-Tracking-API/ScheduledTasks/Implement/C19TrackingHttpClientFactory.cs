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
using Microsoft.Extensions.Logging; 
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.GZip;

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
        public async Task<JObject> SendAsync(string apiKey, Dictionary<string, string> headers = null)
        {
            var apiOption = _apiDataSettings.ListAPIOptions.Where(c => c.Name.Equals(apiKey)).FirstOrDefault();
            if(apiOption != null)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, apiOption.Url);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                request.Headers.Add("Host", "covid19.who.int");
                request.Headers.Add("Cookie", "_gcl_au=1.1.47565036.1629197252; _ga=GA1.2.580925355.1629197253; _clck=xk8q0c|1|ety; _gid=GA1.2.1113256994.1631064692; _gat_gtag_UA_162461105_1=1");

                 

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                } 
                var client = _clientFactory.CreateClient();
                client.Timeout = TimeSpan.FromMinutes(15);
               
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (response.IsSuccessStatusCode)
                { 
                    try  
                    {
                        using (Stream stream = await response.Content.ReadAsStreamAsync())
                        using (GZipInputStream gzipStream = new GZipInputStream(stream))
                        using (StreamReader streamReader = new StreamReader(gzipStream))
                        using (JsonReader reader = new JsonTextReader(streamReader))
                        {
                            reader.SupportMultipleContent = true;
                            return new JsonSerializer().Deserialize<JObject>(reader);
                        } 
                    }
                    catch (NotSupportedException)  
                    {
                        _logger.LogError("The content type is not supported.");
                    }
                    catch (JsonException ex)  
                    {
                        _logger.LogError("Invalid JSON.");
                    }
                    return null;
                } 
            }
            return null;
        }
        static byte[] Decompress(byte[] gzip)
        {
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
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
