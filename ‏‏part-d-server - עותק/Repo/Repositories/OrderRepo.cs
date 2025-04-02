using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderRepo : IRepository<Order>
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

        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(p => p.Id == id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

    }
}
