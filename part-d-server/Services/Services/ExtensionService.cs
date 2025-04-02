using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Dtos;
using Services.Interfaces;
using System;

namespace Services.Services
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services)
        {
            services.AddRepository();

            services.AddScoped<IService<OrderDto>, OrderService>();
            //services.AddScoped<IService<OrderProductDto>, OrderProductService>();
            services.AddScoped<IService<OwnerDto>, OwnerService>();
            //services.AddScoped<IService<ProductDto>, ProductService>();
            services.AddScoped<IService<ProviderDto>, ProviderService>();
            services.AddScoped<IProviderSerivce, ProviderService>();
            

            services.AddAutoMapper(typeof(MyMapper));


             return services;
        }
    }
    
        
}