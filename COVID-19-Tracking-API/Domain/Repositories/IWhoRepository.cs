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
        Task<CovidReportDetail> GetDetailByCountry(BaseRequest<DetailByCountryRequest> request);
        Task<CovidDataByCountry> GetTotalCaseByCountry(BaseRequest<DetailByCountryRequest> request);
        Task<List<CovidDataByRegion>> GetCountryByRegion(BaseRequest<CovidReportDetailRequest> request);
        Task<List<DeathsCountry>> GetTopDeathsByCountry();
        Task<List<CasesCountry>> GetTopCasesByCountry();
        Task<List<CovidDataByCountry>> GetTopByCountry();
    }
}
