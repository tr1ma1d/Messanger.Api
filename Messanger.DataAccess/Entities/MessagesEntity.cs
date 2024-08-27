using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Entities
{
    public class MessagesEntity
    {
        public int id { get; set; }
        public int sender_id { get; set; }
        public int chat_id { get; set; }
        public string chat_type { get; set; }
        public string content { get; set; }
    }
}
