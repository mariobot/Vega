using System.Threading.Tasks;
using Vega.API.Models;

namespace Vega.API.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle _vehicle);
        void Remove(Vehicle _vehicle);
    }
}