using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Entities
{
    public class ChatEntity
    {
        public int id { get; set; }
        public string chat_name { get; set; } = string.Empty;
        public string chat_type { get; set; } = string.Empty;
    }
}
