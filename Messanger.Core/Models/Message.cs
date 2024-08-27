using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Core.Models
{
    public class Message
    {
        private Message(int senderId, int chatId, string chatType, string content)
        {
            SenderId = senderId;
            ChatId = chatId;
            ChatType = chatType;
            Content = content;
        }
  
        public int SenderId { get; }
        public int ChatId { get; }
        public string ChatType { get; }
        public string Content { get; }

        public static (Message message, string error) Create(int senderId, int chatId, string chatType, string content)
        {
            string error = string.Empty;
            Message message = new Message(senderId, chatId, chatType, content);
            return (message, error);
        }

    }
}
