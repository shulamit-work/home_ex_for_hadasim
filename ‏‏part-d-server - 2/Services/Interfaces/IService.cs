using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        T AddItem(T item);

    }

    public interface IProviderSerivce : IService<UserDto>
    {
        UserDto AddProvider(UserDto provider, List<ProductDto> products);

    }
    public interface IOrderSerivce : IService<OrderDto>
    {
        OrderDto AddOrder(OrderDto order, List<OrderProductDto> products);
        OrderDto ConfirmOrder(int id, bool isOwner);//////////////////////////////////////////
        List<OrderDto> GetOrdersByProvderId(int provderId);
    }

    public interface IOrderProductsService : IService<OrderProductDto>
    {
        List<OrderProductDto> GetByOrderId(int id);
    }

    public interface IProductService : IService<ProductDto>
    {
        List<ProductDto> GetByProviderId(int id);
    }

    public interface IMessageToProviderService : IService<MessageToProviderDto>
    {
        List<MessageToProviderDto> GetByProviderId(int providerId);
    }
}
