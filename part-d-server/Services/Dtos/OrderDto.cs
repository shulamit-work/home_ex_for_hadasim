using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public enum OrderStatus
    {
        NEW,
        PROCESSING,
        DONE
    }
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public OrderStatus? Status { get; set; } = OrderStatus.NEW;

        public ICollection<OrderProductDto> OrderProducts { get; set; }
    }
}

