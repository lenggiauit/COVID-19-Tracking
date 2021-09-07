using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Repositories
{
    public interface IWhoRepository
    {
        Task<Covid19Data> GetTotals();
        Task<CovidReportDetail> GetDetailByRegion(BaseRequest<CovidReportDetailRequest> request);
        Task<List<CovidDataByRegion>> GetListCaseByRegion();
        Task<List<CovidDataByCountry>> GetTopByCountry();
        Task<CovidDataByCountry> GetDetailByCountry(BaseRequest<DetailByCountryRequest> request);
    }
}
