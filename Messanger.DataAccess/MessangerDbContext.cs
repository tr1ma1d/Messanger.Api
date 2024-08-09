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
    }
}
