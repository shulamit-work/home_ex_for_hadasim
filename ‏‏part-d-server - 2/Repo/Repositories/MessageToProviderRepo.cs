using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class MessageToProviderRepo : IMessageToProviderRepo
    {
        private readonly IContext context;
        public MessageToProviderRepo(IContext context)
        {
            this.context = context;
        }

        public MessageToProvider AddItem(MessageToProvider item)
        {
            context.MessageToProviders.Add(item);
            context.Save();
            return Get(item.Id);
        }

        public MessageToProvider Get(int id)
        {
            //return GetAll().FirstOrDefault(m=>m.Id == id);
            throw new Exception();
        }

        public List<MessageToProvider> GetAll()
        {
            return context.MessageToProviders.ToList();
        }

        public List<MessageToProvider> GetByProviderId(int providerId)
        {
            return GetAll().Where(m => m.ProviderId == providerId).ToList();
        }
    }
}
