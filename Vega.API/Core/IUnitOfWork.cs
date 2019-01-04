using System.Threading.Tasks;

namespace Vega.API.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}