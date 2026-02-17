using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserStore.Core.Models;
using UserStore.DataAccess.Entities;

namespace UserStore.DataAccess.Configurations;

public class UserAdressConfiguration : IEntityTypeConfiguration<UserAdressEntity>
{
    public void Configure(EntityTypeBuilder<UserAdressEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne<UserEntity>()
            .WithMany(user => user.Adresses)
            .HasForeignKey(x => x.UserId);
    }
}