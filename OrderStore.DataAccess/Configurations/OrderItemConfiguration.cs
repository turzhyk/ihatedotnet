using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderStore.DataAccess.Entities;

namespace OrderStore.DataAccess.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.PricePerUnit)
            .IsRequired();

        // enum → string
        builder.Property(x => x.Type)
            .HasConversion<string>()
            .IsRequired();

        // JSON options
        builder.Property(x => x.Options)
            .HasColumnType("jsonb"); // если PostgreSQL
        // .HasColumnType("nvarchar(max)") для SQL Server

        // связь с заказом
        builder.HasOne(x => x.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
