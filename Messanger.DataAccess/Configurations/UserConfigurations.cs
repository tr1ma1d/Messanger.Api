using Messanger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messanger.DataAccess.Configurations
{
    //CREATE CONFIG FOR FUTURE PROJECTS 


    //YEAP
    public class UserConfigurations : IEntityTypeConfiguration<UserEntity>
    {

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.id);
            //For dateBase configure
            //i made xD
            builder.Property(b => b.username).IsRequired();
            builder.Property(b => b.password).IsRequired();
            builder.Property(b => b.email).IsRequired();
        }
    }
}
