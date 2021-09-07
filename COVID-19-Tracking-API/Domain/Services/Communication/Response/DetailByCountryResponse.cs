using C19Tracking.API.Domain.Services.Communication.Response;
using C19Tracking.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Services.Communication.Response
{
    public class DetailByCountryResponse : BaseResponse<CovidDataByCountryResource>
    {
        public DetailByCountryResponse(CovidDataByCountryResource resource) : base(resource)
        { }
        public DetailByCountryResponse(string message) : base(message)
        { }
        public DetailByCountryResponse(bool success) : base(success)
        { }
    }
}