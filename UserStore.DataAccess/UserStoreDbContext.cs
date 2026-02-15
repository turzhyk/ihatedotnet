using Microsoft.EntityFrameworkCore;
using UserStore.DataAccess.Entities;

namespace UserStore.DataAccess;

public class UserStoreDbContext : DbContext
{
    public UserStoreDbContext(DbContextOptions<UserStoreDbContext> options) : base(options)
    {
    }
    public DbSet<UserEntity> Users { get; set; }
}