using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core.Models
{
    public class PersonalChat
    {
        
        public int User1 { get; }
        public int User2 { get; }
        private PersonalChat(int user1, int user2)
        {
            User1 = user1;
            User2 = user2;
        }
        public static (PersonalChat personalChat, string error) Create(int user1, int user2)
        {
            string error = string.Empty;
            var personalChat = new PersonalChat(user1, user2);
            return (personalChat, error);
        }

       
    }
}
