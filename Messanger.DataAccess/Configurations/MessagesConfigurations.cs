using Messanger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DataAccess.Configurations
{
    public class MessagesConfigurations : IEntityTypeConfiguration<ChatEntity>
    {
        public void Configure(EntityTypeBuilder<ChatEntity> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.chat_name).IsRequired();
            builder.Property(x => x.chat_type).IsRequired();
        }
    }
}
