using C19Tracking.API.Domain.Services.Communication;
using C19Tracking.API.Domain.Services.Communication.Response;
using C19Tracking.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Services.Communication.Response
{ 
    public class CaseByRegionResponse : BaseResponse<CaseByRegionResource>
    {
        public CaseByRegionResponse(CaseByRegionResource resource) : base(resource)
        { }
        public CaseByRegionResponse(string message) : base(message)
        { }
        public CaseByRegionResponse(bool success) : base(success)
        { }
    }

    public class ListCaseByRegionResponse : BaseResponse<List<CaseByRegionResource>>
    {
        public ListCaseByRegionResponse(List<CaseByRegionResource> resources) : base(resources)
        { }
        public ListCaseByRegionResponse(string message) : base(message)
        { }
        public ListCaseByRegionResponse(bool success) : base(success)
        { }
    }


}
 