using Messanger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Configurations
{
    public class ChatMemberConfiguration : IEntityTypeConfiguration<ChatMemberEntity>
    {
        public void Configure(EntityTypeBuilder<ChatMemberEntity> builder)
        {
            builder.Property(x => x.chat_id);
            builder.Property(x => x.user_id);
        }
    }
}
