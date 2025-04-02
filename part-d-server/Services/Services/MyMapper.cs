using AutoMapper;
using Repositories.Entities;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Provider, ProviderDto>().ReverseMap();
           
        }
    }
}