using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.API.Models;
using Vega.API.Persistence;
using Vega.API.Resources;

namespace Vega.API.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly VegaDbContext _context;

        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);                

            var vehicle = await _context.Vehicles.Include(f => f.Features).SingleOrDefaultAsync(x => x.Id == id);

            if(vehicle == null)
                return NotFound();
            
            _mapper.Map<VehicleResource,Vehicle>(vehicleResource,vehicle);

            vehicle.LastUpdate = DateTime.Now;
            
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if(vehicle == null)
                return NotFound();

            _context.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {            
            var vehicle = await _context.Vehicles.Include(f => f.Features).SingleOrDefaultAsync(x => x.Id == id);

            if(vehicle == null)
                return NotFound();
            
            var vehicleResource = _mapper.Map<Vehicle,VehicleResource>(vehicle);

            return Ok(vehicleResource); 
        }
    }
}