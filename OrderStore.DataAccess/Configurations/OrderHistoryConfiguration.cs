using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderStore.Core.Models;
using OrderStore.DataAccess.Entities;

namespace OrderStore.DataAccess.Configurations;

public class OrderHistoryConfiguration:IEntityTypeConfiguration<OrderHistoryElementEntity>

{
        public void Configure(EntityTypeBuilder<OrderHistoryElementEntity> builder)
        {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Status)
                        .IsRequired()
                        .HasMaxLength(50);

                builder.Property(x => x.AuthorLogin)
                        .IsRequired()
                        .HasMaxLength(100);

                builder.Property(x => x.ChangedAt)
                        .IsRequired();

                builder.HasOne(x => x.Order)
                        .WithMany(o => o.History)
                        .HasForeignKey(x => x.OrderId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
}