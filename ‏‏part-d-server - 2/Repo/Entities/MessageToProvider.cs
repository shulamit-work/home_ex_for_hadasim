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

        public MessageToProvider(int userId, string text)
        {
            UserId = userId;
            Text= text;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public string Text { get; set; }
    }
}
