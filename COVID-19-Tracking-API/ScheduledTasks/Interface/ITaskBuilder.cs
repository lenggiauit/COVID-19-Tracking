using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Interface
{
   public  interface ITaskBuilder 
    {
        Task<bool> Invoke(ILogger logger); 
    }
}