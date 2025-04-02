using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IContext context;
        public OrderRepo(IContext context)
        {
            this.context = context;
        }

        public Order AddItem(Order item)
        {
            context.Orders.Add(item);
            context.Save();
            return Get(item.Id);
        }

        public Order ConfirmOrder(int id, OrderStatus status)
        {
            Order order = Get(id);
            if (order != null)
            {
                order.Status = status;
                context.Save();
            }
            return Get(order.Id);
        }

        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(p => p.Id == id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public List<Order> GetOrdersByProvderId(int providerId)
        {
            return GetAll().Where(o => o.ProviderId == providerId).ToList();    
        }
    }
}
