using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Domain.Services;
using C19Tracking.API.Domain.Services.Communication.Request; 
using System.Threading.Tasks;

namespace C19Tracking.API.Services
{
    public class WhoService : IWhoService
    {
        private readonly IWhoRepository _ourServiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WhoService(IWhoRepository ourServiceRepository, IUnitOfWork unitOfWork)
        {
            this._ourServiceRepository = ourServiceRepository;
            _unitOfWork = unitOfWork;
        }

        public Task GetData(string request)
        {
            throw new System.NotImplementedException();
        }
    }
}
