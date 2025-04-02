using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }





        void Save();

    }
}
