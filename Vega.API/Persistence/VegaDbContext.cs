using Microsoft.EntityFrameworkCore;
using Vega.API.Models;

namespace Vega.API.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base (options)
        {
        }
        
        public DbSet<Make> Makes { get; set; }
        
    }
}