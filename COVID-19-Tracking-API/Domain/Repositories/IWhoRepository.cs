using C19Tracking.API.Domain.Services.Communication.Request;
using C19Tracking.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Repositories
{
    public interface IWhoRepository
    {
        Task<Covid19Data> GetTotals();
        Task<CovidDataByRegion> GetCaseByRegion(string regionCode);
        Task<List<CovidDataByRegion>> GetListCaseByRegion();

        

    }
}
