using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.API.Models;

namespace Vega.API.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _context;

        public VehicleRepository(VegaDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _context.Vehicles.FindAsync(id);

            var vehicle = await _context.Vehicles
               .Include(f => f.Features)
                   .ThenInclude(vf => vf.Feature)
               .Include(m => m.Model)
                   .ThenInclude(m => m.Make)
               .SingleOrDefaultAsync(x => x.Id == id);
            
            return vehicle;
        }

        public void Add(Vehicle _vehicle)
        {
            _context.Vehicles.Add(_vehicle);
        }

        public void Remove(Vehicle _vehicle)
        {
            _context.Vehicles.Remove(_vehicle);
        }
    }
}