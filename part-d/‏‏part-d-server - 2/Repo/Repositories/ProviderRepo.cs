using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private readonly IContext context;
        public UserRepo(IContext context)
        {
            this.context = context;
        }

        public User AddItem(User item)
        {
            context.Users.Add(item);
            context.Save();
            return Get(item.Id);
        }

        public User Get(int id)
        {
            return context.Users.FirstOrDefault(p => p.Id == id);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

    }
}
