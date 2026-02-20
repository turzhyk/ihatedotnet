using Microsoft.EntityFrameworkCore;
using ProductStore.DataAccess.Entities;

namespace ProductStore.DataAccess;

public class ProductStoreDbContext:DbContext
{
    public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options) :base(options)
    {
        
    }
    public DbSet<BusinesscardEntity> Businesscards {get;set;}
}