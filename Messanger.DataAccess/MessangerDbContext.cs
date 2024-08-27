using Messanger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messanger.DataAccess
{
    public class MessangerDbContext : DbContext
    {
        public MessangerDbContext(DbContextOptions<MessangerDbContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> users { get; set; }
        public DbSet<ChatEntity> chats { get; set; }
        public DbSet<ChatMemberEntity> chatmembers { get; set; }
        public DbSet<MessagesEntity> messages { get; set; } 
        public DbSet<PersonalChatEntity> personalchats { get; set; }
        
    }
}
