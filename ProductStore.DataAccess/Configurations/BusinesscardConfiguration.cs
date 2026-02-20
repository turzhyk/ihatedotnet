using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.DataAccess.Entities;

namespace ProductStore.DataAccess.Configurations;

public class BusinesscardConfiguration : IEntityTypeConfiguration<BusinesscardEntity>
{
    public void Configure(EntityTypeBuilder<BusinesscardEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price);
        builder.Property(x => x.Finish);
        builder.Property(x => x.Density);
    }
}