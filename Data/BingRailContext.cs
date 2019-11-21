using Microsoft.EntityFrameworkCore;
using BinghamRailroad.Models;

namespace BinghamRailroad.Data {
    public class BingRailContext : DbContext {
        public BingRailContext (DbContextOptions<BingRailContext> options)
            : base(options)
        {}

        public DbSet<Train> Train { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Rider> Rider { get; set; }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<TrainAmenity> TrainAmenity { get; set; }
        public DbSet<StationAmenity> StationAmenity { get; set; }
    }
}