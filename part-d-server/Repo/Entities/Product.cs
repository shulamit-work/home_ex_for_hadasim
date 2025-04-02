using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PricePer1 { get; set; }
        public int MinCount { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider? Prov { get; set; }
    }
}
