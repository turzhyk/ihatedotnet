using Microsoft.EntityFrameworkCore;
using OrderStore.Core.Models;
using OrderStore.DataAccess.Entities;

namespace OrderStore.DataAccess
{
    public class OrderStoreDbContext : DbContext
    {
        public OrderStoreDbContext(DbContextOptions<OrderStoreDbContext> options):base(options)
        {
            
        }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<OrderHistoryElementEntity> OrderStatusHistories { get; set; }

    }
}
