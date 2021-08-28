using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services;
using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.Domain.Models.Entities;
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
         
        public async Task<Covid19Data> GetTotals()
        {
            return await _whoServiceRepository.GetTotals();
        }
    }
}
