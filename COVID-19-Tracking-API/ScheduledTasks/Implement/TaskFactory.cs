using C19Tracking.ScheduledTasks.Enums;
using C19Tracking.ScheduledTasks.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Implement
{
    public class TaskFactory : ITaskFactory 
    {
        public ITaskBuilder CreateInstant(string flowTaskName, TaskResolver taskResolver)
        { 
            switch (flowTaskName)
            {
                case nameof(FlowTask.GetWHOData):
                    return (GetWHOData)taskResolver(FlowTask.GetWHOData);
                case nameof(FlowTask.ProcessData):
                    return (ProcessData)taskResolver(FlowTask.ProcessData);
                case nameof(FlowTask.CleanUpData):
                    return (CleanUpData)taskResolver(FlowTask.CleanUpData);
                case nameof(FlowTask.SaveToCache):
                    return (SaveToCache)taskResolver(FlowTask.SaveToCache);
                default:
                    return null; 
            }

        } 
    }
}
