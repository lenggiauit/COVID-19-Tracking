using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.ScheduledTasks.Enums
{
    public enum FlowTask
    { 
        [Description("Get data from WHO API")]
        GetWHOData = 1,
        [Description("Process data")]
        ProcessData = 2,
        [Description("Clean up current raw data")]
        CleanUpRawData = 3,
        [Description("Save data to Database")]
        SaveToDatabase = 4 
    }
}
