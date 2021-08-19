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
    }
}
