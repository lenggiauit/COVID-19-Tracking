using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using C19Tracking.API.Domain.Helpers;
using C19Tracking.API.Domain.Services;
using C19Tracking.API.Domain.Services.Communication;
using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.API.Domain.Services.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C19Tracking.Domain.Services.Communication.Response;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Resources;

namespace C19Tracking.Controllers
{
    public class WhoController : Controller
    {
        private readonly IWhoService _whoServices; 
        private readonly ILogger<WhoController> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        public WhoController(
            ILogger<WhoController> logger,
            IWhoService whoServices, 
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _whoServices = whoServices; 
            _mapper = mapper;
            _appSettings = appSettings.Value;

        }
        [HttpPost("totalsCase")]
        public async Task<TotalsResponse> TotalsCase([FromBody] BaseRequest<string> request)
        {
            if (ModelState.IsValid)
            {
                var totals = await _whoServices.GetTotals(request);
                var resources = _mapper.Map<Covid19Data,  TotalsResource>(totals);
                return new TotalsResponse(resources);
            }
            else
            {
                return new TotalsResponse(string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }

        } 
    }
}
