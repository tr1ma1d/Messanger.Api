using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core.Models
{
    public class ChatMember
    {
        public int ChatId { get; }
        public int UserId { get; }

        private ChatMember (int chatId, int userId)
        {
            ChatId = chatId;    
            UserId = userId;
        }

        public static (ChatMember chatMember, string Error) Create(int chatId, int userId)
        {
            var error = string.Empty;
            var chatMembers = new ChatMember(chatId, userId);
            return (chatMembers, error);
        }
    }
}
