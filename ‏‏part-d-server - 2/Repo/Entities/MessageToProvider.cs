using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class MessageToProvider
    {

        public MessageToProvider(int providerId, string text)
        {
            ProviderId = providerId;
            Text= text;
        }

        public int Id { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider? Provider { get; set; }
        public string Text { get; set; }
    }
}
