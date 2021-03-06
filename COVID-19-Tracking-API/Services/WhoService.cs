using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services;
using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Domain.Services.Communication.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C19Tracking.API.Services
{
    public class WhoService : IWhoService
    {
        private readonly IWhoRepository _whoServiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WhoService(IWhoRepository whoServiceRepository, IUnitOfWork unitOfWork)
        {
            this._whoServiceRepository = whoServiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CovidDataByRegion>> GetListCaseByRegion()
        {
            return await _whoServiceRepository.GetListCaseByRegion();
        }
 
        public async Task<Covid19Data> GetTotals()
        {
            return await _whoServiceRepository.GetTotals();
        } 

        public async Task<CovidReportDetail> GetDetailByRegion(BaseRequest<CovidReportDetailRequest> request)
        {
            return await _whoServiceRepository.GetDetailByRegion(request);
        }

        public async Task<List<CovidDataByCountry>> GetTopByCountry()
        {
            return await _whoServiceRepository.GetTopByCountry();
        }

        public async Task<List<DeathsCountry>> GetTopDeathsByCountry()
        {
            return await _whoServiceRepository.GetTopDeathsByCountry();
        }

        public async Task<List<CasesCountry>> GetTopCasesByCountry()
        {
            return await _whoServiceRepository.GetTopCasesByCountry();
        }

        public async Task<CovidReportDetail> GetDetailByCountry(BaseRequest<DetailByCountryRequest> request)
        {
            return await _whoServiceRepository.GetDetailByCountry(request);
        }

        public async Task<CovidDataByCountry> GetTotalCaseByCountry(BaseRequest<DetailByCountryRequest> request)
        {
            return await _whoServiceRepository.GetTotalCaseByCountry(request);
        }
         

        public async Task<List<CovidDataByRegion>> GetCountryByRegion(BaseRequest<CovidReportDetailRequest> request)
        {
            return await _whoServiceRepository.GetCountryByRegion(request);
        }

       
    }
}
