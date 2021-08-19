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
        /// <summary>
        /// Create Instant of Task
        /// </summary>
        /// <param name="flowTaskName"></param>
        /// <param name="taskResolver"></param>
        /// <returns></returns>
        public ITaskBuilder CreateInstant(string flowTaskName, TaskResolver taskResolver)
        { 
            switch (flowTaskName)
            {
                case nameof(FlowTask.GetWHOData):
                    return (GetWHOData)taskResolver(FlowTask.GetWHOData);
                case nameof(FlowTask.ProcessData):
                    return (ProcessData)taskResolver(FlowTask.ProcessData);
                case nameof(FlowTask.CleanUpRawData):
                    return (CleanUpRawData)taskResolver(FlowTask.CleanUpRawData);
                case nameof(FlowTask.SaveToDatabase):
                    return (SaveToDatabase)taskResolver(FlowTask.SaveToDatabase);
                default:
                    return null; 
            }

        } 
    }
}
