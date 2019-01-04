using System.Threading.Tasks;

namespace Vega.API.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}