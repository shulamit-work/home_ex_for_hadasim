using Microsoft.Extensions.DependencyInjection;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories.Repositories
{
    public static class ExtensionMethod
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Order>, OrderRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IRepository<OrderProduct>, OrderProductRepo>();
            services.AddScoped<IOrderProductRepo, OrderProductRepo>();
            services.AddScoped<IRepository<Owner>, OwnerRepo>();
            services.AddScoped<IRepository<Product>, ProductRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IRepository<Provider>, ProviderRepo>();
            services.AddScoped<IRepository<MessageToProvider>, MessageToProviderRepo>();
            services.AddScoped<IMessageToProviderRepo, MessageToProviderRepo>();
            

            return services;
        }
    }
}
