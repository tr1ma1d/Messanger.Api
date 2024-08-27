using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core.Models
{
    public class Chat
    {
        private Chat(string chatName, string chatType) {
            ChatName = chatName;
            ChatType = chatType;
        }

        public int Id { get; }
        public string ChatName { get; } = string.Empty;
        public string ChatType { get; } = string.Empty;


        public static (Chat chat, string Error) Create(string chatName, string chatType)
        {
            var error = string.Empty; 
            if(string.IsNullOrEmpty(chatName))
            {
                return(null, error);
            }
            var chat = new Chat(chatName, chatType);
            return (chat, error);
        }
    }
}
