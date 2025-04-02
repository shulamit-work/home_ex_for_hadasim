using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class OrderProduct
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Prod { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

        public int Count { get; set; } 
    }
}
