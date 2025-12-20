using Microsoft.EntityFrameworkCore;
using ProductA.Models;

namespace ProductA
{
    public class ProductContext : DbContext
    {
        // TPCT (Default)
        public DbSet<Book> Books { get; set; }
        public DbSet<Electronics> Electronics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ABDULRAHMAN\\MSSQLS;Database=ProductInheritanceDb;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .UseTpcMappingStrategy();

            base.OnModelCreating(modelBuilder);
        }
    }
}