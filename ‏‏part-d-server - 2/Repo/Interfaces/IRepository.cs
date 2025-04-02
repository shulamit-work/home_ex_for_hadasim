using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        T AddItem(T item);
        //T Update(int id, T entity);
    }

    public interface IOrderProductRepo : IRepository<OrderProduct>
    {
        List<OrderProduct> GetByOrderId(int id);
    }

    public interface IProductRepo : IRepository<Product>
    {
        List<Product> GetByProviderId(int id);
    }

    public interface IOrderRepo: IRepository<Order>
    {
        Order ConfirmOrder(int id, OrderStatus status);
        List<Order> GetOrdersByProvderId(int providerId);
    }

    public interface IMessageToProviderRepo : IRepository<MessageToProvider>
    {
        List<MessageToProvider> GetByProviderId(int providerId);
    }

} 