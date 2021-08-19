using C19Tracking.ScheduledTasks.Enums;
using C19Tracking.ScheduledTasks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks
{
    public delegate ITaskBuilder TaskResolver(FlowTask taskType);
}
