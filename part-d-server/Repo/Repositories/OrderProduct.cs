using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderProductRepo : IRepository<OrderProduct>
    {
        private readonly IContext context;
        public OrderProductRepo(IContext context)
        {
            this.context = context;
        }

        public OrderProduct AddItem(OrderProduct item)
        {
            context.OrderProducts.Add(item);
            context.Save();
            return item;
        }

        public OrderProduct Get(int id)
        {
            return context.OrderProducts.Find(id);
        }

        public List<OrderProduct> GetAll()
        {
            return context.OrderProducts.ToList();
        }

    }
}
