﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MessageToProvider> MessageToProviders { get; set; }





        void Save();

    }
}
