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
using C19Tracking.Domain.Services.Communication.Request;

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
        [HttpGet("GetTotalsCase")]
        public async Task<TotalsResponse> GetTotalsCase()
        { 
            var totals = await _whoServices.GetTotals();
            var resources = _mapper.Map<Covid19Data,  TotalsResource>(totals);
            return new TotalsResponse(resources); 
        }

        [HttpPost("GetDetailByRegion")]
        public async Task<CovidReportDetailResponse> GetDetailByRegion([FromBody]BaseRequest<CovidReportDetailRequest> request)
        {
            if (ModelState.IsValid) 
            {
                var detail = await _whoServices.GetDetailByRegion(request);
                var resources = _mapper.Map<CovidReportDetail, CovidReportDetailResource>(detail);
                return new CovidReportDetailResponse(resources);
            }
            else
            { 
                return new CovidReportDetailResponse(string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }
        }

        [HttpGet("GetAllCaseByRegion")]
        public async Task<ListCaseByRegionResponse> GetListCaseByRegion()
        {
            var listCaseByRegion = await _whoServices.GetListCaseByRegion();
            var resources = _mapper.Map<List<CovidDataByRegion>, List<CaseByRegionResource>>(listCaseByRegion);
            return new ListCaseByRegionResponse(resources);
        }

        [HttpGet("GetTopByCountry")]
        public async Task<ListCaseByCountryResponse> GetTopByCountry()
        {
            var listCaseByCountry = await _whoServices.GetTopByCountry();
            var resources = _mapper.Map<List<CovidDataByCountry>, List<CovidDataByCountryResource>>(listCaseByCountry);
            return new ListCaseByCountryResponse(resources);
        }

        [HttpPost("GetTotalCaseByCountry")]
        public async Task<DetailByCountryResponse> GetTotalCaseByCountry([FromBody] BaseRequest<DetailByCountryRequest> request)
        {
            if (ModelState.IsValid)
            {
                var detailByCountry = await _whoServices.GetTotalCaseByCountry(request);
                var resources = _mapper.Map<CovidDataByCountry, CovidDataByCountryResource>(detailByCountry);
                return new DetailByCountryResponse(resources);
            }
            else
            {
                return new DetailByCountryResponse(string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }
        }

        [HttpPost("GetDetailByCountry")]
        public async Task<CovidReportDetailResponse> GetDetailByCountry([FromBody] BaseRequest<DetailByCountryRequest> request)
        {
            if (ModelState.IsValid)
            {
                var detailByCountry = await _whoServices.GetDetailByCountry(request); 
                var resources = _mapper.Map<CovidReportDetail, CovidReportDetailResource>(detailByCountry);
                return new CovidReportDetailResponse(resources);
            }
            else
            {
                return new CovidReportDetailResponse(string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }
        }


        [HttpPost("GetCountriesByRegion")]
        public async Task<ListCaseByRegionResponse> GetCountryByRegion([FromBody] BaseRequest<CovidReportDetailRequest> request)
        {
            if (ModelState.IsValid)
            {
                var listCountryByRegion = await _whoServices.GetCountryByRegion(request);
                var resources = _mapper.Map<List<CovidDataByRegion>, List<CaseByRegionResource>>(listCountryByRegion);
                return new ListCaseByRegionResponse(resources);
            }
            else
            {
                return new ListCaseByRegionResponse(string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }
        }
         

    }
}
