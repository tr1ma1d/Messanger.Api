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
    public class PersonalChatConfig : IEntityTypeConfiguration<PersonalChatEntity>
    {
        public void Configure(EntityTypeBuilder<PersonalChatEntity> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.user1_id).IsRequired();
            builder.Property(x => x.user2_id);
        }
    }
}
