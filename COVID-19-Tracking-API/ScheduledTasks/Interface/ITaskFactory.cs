using C19Tracking.ScheduledTasks.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Interface
{
    public interface ITaskFactory
    {
        ITaskBuilder CreateInstant(string flowTaskName, TaskResolver taskResolver);
    }
}
