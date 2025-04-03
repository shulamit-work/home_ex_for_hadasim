using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public enum OrderStatus
    {
        NEW,
        PROCESSING,
        DONE
    }
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? Prov { get; set; }

        public OrderStatus? Status { get; set; } = OrderStatus.NEW;
    }
}

