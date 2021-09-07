using C19Tracking.API.Domain.Services.Communication.Response;
using C19Tracking.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Services.Communication.Response
{
    public class CaseByCountryResponse : BaseResponse<CovidDataByCountryResource>
    {
        public CaseByCountryResponse(CovidDataByCountryResource resource) : base(resource)
        { }
        public CaseByCountryResponse(string message) : base(message)
        { }
        public CaseByCountryResponse(bool success) : base(success)
        { }
    }


    public class ListCaseByCountryResponse : BaseResponse<List<CovidDataByCountryResource>>
    {
        public ListCaseByCountryResponse(List<CovidDataByCountryResource> resources) : base(resources)
        { }
        public ListCaseByCountryResponse(string message) : base(message)
        { }
        public ListCaseByCountryResponse(bool success) : base(success)
        { }
    }
}
