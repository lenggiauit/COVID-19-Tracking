using C19Tracking.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly C19TrackingContext _context;

        protected BaseRepository(C19TrackingContext context)
        {
            _context = context;
        }
    }
}