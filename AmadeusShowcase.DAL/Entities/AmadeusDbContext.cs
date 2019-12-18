using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AmadeusShowcase.DAL.Entities
{
    public class AmadeusDbContext : DbContext
    {
        public AmadeusDbContext() : base("AmadeusDb")
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Search> Searches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}