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
        public DbSet<Crew> Crews { get; set; }
        public DbSet<FlightAssignment> FlightAssignments { get; set; }

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
            // 1-M (T): A-E
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Airline)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AL_Id)
                .OnDelete(DeleteBehavior.Restrict);

            // 1-M (T): A-AC
            modelBuilder.Entity<Aircraft>()
                .HasOne(c => c.Airline)
                .WithMany(a => a.Aircrafts)
                .HasForeignKey(c => c.AL_Id);

            // 1-M (T): A-T
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Airline)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AL_Id);


            // Multivalued Attribute: Airline Phones (Composite Key)
            modelBuilder.Entity<Airline_Phone>()
                .HasKey(ap => new { ap.AL_Id, ap.Phone });

            // Multivalued Attribute: Employee Qualifications (Composite Key)
            modelBuilder.Entity<Emp_Qualification>()
                .HasKey(eq => new { eq.Emp_Id, eq.Qualification });


            // M-N Relationship: Aircraft <-> Route
            modelBuilder.Entity<FlightAssignment>()
                .HasKey(fa => new { fa.AircraftId, fa.RouteId }); 

            modelBuilder.Entity<FlightAssignment>()
                .HasOne(fa => fa.Aircraft)
                .WithMany(a => a.FlightAssignments)
                .HasForeignKey(fa => fa.AircraftId);

            modelBuilder.Entity<FlightAssignment>()
                .HasOne(fa => fa.Route)
                .WithMany(r => r.FlightAssignments)
                .HasForeignKey(fa => fa.RouteId);


            // 1-1: Aircraft (T) <-> Crew (T)
            modelBuilder.Entity<Crew>().ToTable("Aircrafts").HasKey(c => c.AircraftId);
            modelBuilder.Entity<Aircraft>()
                .HasOne(a => a.Crew)
                .WithOne(c => c.Aircraft)
                .HasForeignKey<Crew>(c => c.AircraftId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
