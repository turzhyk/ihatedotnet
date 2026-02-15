using Microsoft.EntityFrameworkCore;
using UserStore.Core.Models;
using UserStore.DataAccess.Entities;

namespace UserStore.DataAccess.Repos;

public class UsersRepository : IUsersRepository
{
    public readonly UserStoreDbContext _context;

    public UsersRepository(UserStoreDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (userEntity == null)
            throw new Exception($"user with email {email} doesn't exist");
        return new User(userEntity.Id, userEntity.Login, userEntity.PasswordHash, userEntity.Email, userEntity.Role,
            userEntity.CreatedAt);
    }

    public async Task<Guid> CreateAsync(User user)
    {
        var userEntity = new UserEntity(user.Id, user.Login, user.PasswordHash, user.Email, user.Role, user.CreatedAt);
        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
        return user.Id;
    }
}