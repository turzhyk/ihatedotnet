using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderStore.DataAccess.Entities;

namespace OrderStore.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Descriprion).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired();
            builder.Property(o => o.AssignedTo).IsRequired();
            builder.Property(o => o.CreatedAt).IsRequired();
            builder.HasMany(o => o.History)
                .WithOne(h => h.Order)
                .HasForeignKey(h => h.OrderId);
        }
    }
}
