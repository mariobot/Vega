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

        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Model> Models { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(x => new {x.VehicleId, x.FeatureId});
        }
        
    }
}