using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Entities
{
    public class ChatMemberEntity
    {
        public int chat_id { get; set; }
        public int user_id { get; set; }
    }
}
