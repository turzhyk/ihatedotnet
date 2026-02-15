using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserStore.Core.Models;
using UserStore.DataAccess.Entities;

namespace UserStore.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Login).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.Role).IsRequired();
        builder.Property(o => o.CreatedAt).IsRequired();
    }
}