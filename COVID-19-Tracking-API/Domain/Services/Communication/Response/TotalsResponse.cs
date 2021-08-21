using C19Tracking.API.Domain.Services.Communication;
using C19Tracking.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.Domain.Services.Communication.Response
{
    public class TotalsResponse : BaseResponse<TotalsResource>
    {
        public TotalsResponse(TotalsResource resource) : base(resource)
        { }
        public TotalsResponse(string message) : base(message)
        { }
        public TotalsResponse(bool success) : base(success)
        { }
    }
}
