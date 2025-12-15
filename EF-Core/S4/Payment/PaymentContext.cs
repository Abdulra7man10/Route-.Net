using Microsoft.EntityFrameworkCore;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment
{
    public class PaymentContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ABDULRAHMAN\\MSSQLS;Database=PaymentInheritanceDb;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCardPayment>().ToTable("CreditCardPayments");
            modelBuilder.Entity<CashPayment>().ToTable("CashPayments");

            base.OnModelCreating(modelBuilder);
        }
    }
}
