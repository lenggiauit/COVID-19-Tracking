using C19Tracking.API.Domain.Repositories;
using C19Tracking.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly C19TrackingContext _context; 
        public UnitOfWork(C19TrackingContext context)
        {
            _context = context;
        } 
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}