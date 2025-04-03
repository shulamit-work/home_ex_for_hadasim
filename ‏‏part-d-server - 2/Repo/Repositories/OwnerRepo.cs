//using Repositories.Entities;
//using Repositories.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repositories.Repositories
//{
//    public class OwnerRepo : IRepository<Owner>
//    {
//        private readonly IContext context;
//        public OwnerRepo(IContext context)
//        {
//            this.context = context;
//        }
//        public List<Owner> GetAll()
//        {
//            return context.Owner.ToList();
//        }

//        //are no needed
//        public Owner AddItem(Owner item)
//                    {
//                        throw new NotImplementedException();
//                    }

//                    public Owner Get(int id)
//                    {
//                        throw new NotImplementedException();
//                    }

        
//    }
//}
