using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Domain.Services.Communication.Request;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Services
{
    public interface IWhoService
    {
        Task<Covid19Data> GetTotals();
        Task<CovidReportDetail> GetDetailByRegion(BaseRequest<CovidReportDetailRequest> request);
        Task<List<CovidDataByRegion>> GetListCaseByRegion(); 
    }
}
