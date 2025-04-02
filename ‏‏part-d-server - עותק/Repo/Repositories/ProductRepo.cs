using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ProductRepo : IRepository<Product>
    {
        private readonly IContext context;
        public ProductRepo(IContext context)
        {
            this.context = context;
        }

        public Product AddItem(Product item)
        {
            context.Products.Add(item);
            context.Save();
            return Get(item.Id);
        }

        public Product Get(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

    }
}
