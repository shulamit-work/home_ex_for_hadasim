using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mock
{
    public class DB : DbContext, IContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }



        public void Save()
        {
            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=sql;database=Grocery;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // הגדרת אינדקסים ייחודיים עבור המודל User

            modelBuilder.Entity<Provider>()
                .HasIndex(p => p.Phone)
                .IsUnique();

            modelBuilder.Entity<Provider>()
                .HasIndex(p => p.Password)
                .IsUnique();


            modelBuilder.Entity<OrderProduct>()
           .HasKey(op => new { op.OrderId, op.ProductId });
        }
    }
}