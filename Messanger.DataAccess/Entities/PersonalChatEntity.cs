using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Entities
{
    public class PersonalChatEntity
    {
        public int id { get; set; }
        public int user1_id { get; set; }
        public int user2_id { get; set; }
    }
}
