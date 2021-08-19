using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}