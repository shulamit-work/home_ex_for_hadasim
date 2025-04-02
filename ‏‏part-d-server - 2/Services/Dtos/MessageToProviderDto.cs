using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class MessageToProviderDto
    {

        public MessageToProviderDto(int providerId, string text)
        {
            ProviderId = providerId;
            Text= text;
        }

        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Text { get; set; }
    }
}
