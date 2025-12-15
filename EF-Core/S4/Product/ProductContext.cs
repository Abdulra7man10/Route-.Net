using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product
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
    }
}