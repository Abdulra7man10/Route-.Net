using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SectionC_Inh.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

public class VehicleContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

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
        // Table-Per-Hierarchy (TPH)
        modelBuilder.Entity<Vehicle>()
            .HasDiscriminator<string>("VehicleType")
            .HasValue<Car>("Car")
            .HasValue<Bus>("Bus");

        base.OnModelCreating(modelBuilder);
    }
}