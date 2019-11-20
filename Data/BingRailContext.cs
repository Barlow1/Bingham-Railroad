using Microsoft.EntityFrameworkCore;
using BinghamRailroad.Models;

namespace BinghamRailroad.Data {
    public class BingRailContext : DbContext {
        public BingRailContext (DbContextOptions<BingRailContext> options)
            : base(options)
        {}

        public DbSet<Train> Train { get; set; }
    }
}