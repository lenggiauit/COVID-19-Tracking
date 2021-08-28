using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.API.Infrastructure;
using C19Tracking.API.Persistence.Contexts;
using C19Tracking.API.Persistence.Repositories;
using C19Tracking.Domain.Models.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Persistence.Repositories
{
    public class WhoRepository : BaseRepository, IWhoRepository
    {
        private readonly ILogger<WhoRepository> _logger;
        private readonly IDistributedCache _distributedCache;
        public WhoRepository(C19TrackingContext context, ILogger<WhoRepository> logger, IDistributedCache distributedCache) : base(context) {
            _distributedCache = distributedCache;
            _logger = logger;
        }
        public async Task<Covid19Data> GetTotals()
        { 
            string jsonString =  await _distributedCache.GetStringAsync(CacheKeys.Totals.ToString());
            if (!string.IsNullOrEmpty(jsonString))
            {
                string jsonUpdatedDate = await _distributedCache.GetStringAsync(CacheKeys.LastUpdate.ToString());
                Covid19Data covid19Data = JsonConvert.DeserializeObject<Covid19Data>(jsonString);
                covid19Data.UpdatedDate = DateTime.Parse(jsonUpdatedDate); 
                return covid19Data;
            }
            else
            {
                _logger.LogWarning($"Cache {CacheKeys.Totals} is empty!");
                return null;
            } 
        }
    }
}
