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
            services.AddScoped<IOrderSerivce, OrderService>();
            services.AddScoped<IService<OrderProductDto>, OrderProductService>();
            services.AddScoped<IOrderProductsService, OrderProductService>();
            services.AddScoped<IService<MessageToProviderDto>, MessageToProviderService>();
            services.AddScoped<IMessageToProviderService, MessageToProviderService>();
            services.AddScoped<IService<ProductDto>, ProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IService<UserDto>, UserService>();
            services.AddScoped<IProviderSerivce, UserService>();
            services.AddScoped<ILoginService, LoginService>();


            services.AddAutoMapper(typeof(MyMapper));


             return services;
        }
    }
    
        
}