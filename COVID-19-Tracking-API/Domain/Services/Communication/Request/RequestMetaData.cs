﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Services.Communication.Request
{
    public class RequestMetaData
    {
        public Paging Paging { get; set; }
        public string[] SortBy { get; set; }
        public string[] OrderBy { get; set; } 
    }
    public class Paging
    {
        public int Index { get; set; }
        public int Size { get; set; }
    }
}
