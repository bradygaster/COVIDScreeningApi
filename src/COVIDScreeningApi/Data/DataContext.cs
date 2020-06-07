using Microsoft.EntityFrameworkCore;

namespace COVIDScreeningApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PortOfEntry> Ports { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Screening> Screenings { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PortOfEntry>()
                    .ToContainer("PortsOfEntry")
                    .HasNoDiscriminator()
                    .HasPartitionKey(x => x.PartitionKey);

            modelBuilder
                .Entity<Representative>()
                    .ToContainer("Representatives")
                    .HasNoDiscriminator()
                    .HasPartitionKey(x => x.PartitionKey);

            modelBuilder
                .Entity<Screening>()
                    .ToContainer("Screenings")
                    .HasNoDiscriminator()
                    .HasPartitionKey(x => x.PartitionKey);
        }
    }
}