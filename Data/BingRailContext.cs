using Microsoft.EntityFrameworkCore;
using BinghamRailroad.Models;

namespace BinghamRailroad.Data {
    public class BingRailContext : DbContext {
        public BingRailContext (DbContextOptions<BingRailContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenity>()
                .HasAlternateKey(a => a.Name);

            modelBuilder.Entity<Station>()
                .HasAlternateKey(s => s.Name);

            modelBuilder.Entity<Rider>()
                .HasAlternateKey(r => r.UserName);

            modelBuilder.Entity<TrainAmenity>()
                .HasAlternateKey( ta => new {ta.AmenityId, ta.TrainId});

            modelBuilder.Entity<StationAmenity>()
                .HasAlternateKey( sa => new {sa.AmenityId, sa.StationId});
        }

        public DbSet<Train> Train { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Rider> Rider { get; set; }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<TrainAmenity> TrainAmenity { get; set; }
        public DbSet<StationAmenity> StationAmenity { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}