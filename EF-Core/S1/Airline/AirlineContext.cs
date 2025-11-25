using Airline.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection.Emit;

namespace Airline
{

    public class AirlineContext : DbContext
    {
        public DbSet<AirLine> Airlines { get; set; }
        public DbSet<Airline_Phone> AirlinePhones { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Emp_Qualification> EmpQualifications { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Aircraft_Route> AircraftRoutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline_Phone>()
                .HasKey(p => new { p.AL_Id, p.Phone });

            modelBuilder.Entity<Emp_Qualification>()
                .HasKey(q => new { q.Emp_Id, q.Qualification });

            modelBuilder.Entity<Aircraft_Route>()
                .HasKey(ar => new { ar.AC_Id, ar.Route_Id });

            base.OnModelCreating(modelBuilder);
        }
    }
}
