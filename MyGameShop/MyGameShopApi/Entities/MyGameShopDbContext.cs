using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace MyGameShopApi.Entities
{
    public class MyGameShopDbContext : DbContext
    {
        private string connectionString = "Server=MSI\\SQLEXPRESS;Database=MyGameShop;Trusted_Connection=True";

        public DbSet<Product> Products { get; set; }
        public DbSet<Pegi> Pegis { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Receipt>()
                .Property(r => r.IsInvoiceIssued)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
