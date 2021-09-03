using C19Tracking.API.Domain.Services.Communication;
using C19Tracking.API.Domain.Services.Communication.Response;
using C19Tracking.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Services.Communication.Response
{
    public class CovidReportDetailResponse : BaseResponse<CovidReportDetailResource>
    {
        public CovidReportDetailResponse(CovidReportDetailResource resource) : base(resource)
        { }
        public CovidReportDetailResponse(string message) : base(message)
        { }
        public CovidReportDetailResponse(bool success) : base(success)
        { }
    }
}
