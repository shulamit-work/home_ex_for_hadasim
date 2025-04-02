using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ProviderRepo : IRepository<Provider>
    {
        private readonly IContext context;
        public ProviderRepo(IContext context)
        {
            this.context = context;
        }

        public Provider AddItem(Provider item)
        {
            context.Providers.Add(item);
            context.Save();
            return Get(item.Id);
        }

        public Provider Get(int id)
        {
            return context.Providers.FirstOrDefault(p => p.Id == id);
        }

        public List<Provider> GetAll()
        {
            return context.Providers.ToList();
        }

    }
}
