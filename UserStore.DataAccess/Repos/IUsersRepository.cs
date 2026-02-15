using UserStore.Core.Models;

namespace UserStore.DataAccess.Repos;

public interface IUsersRepository
{
    Task<Guid> CreateAsync(User user);
    Task<User> GetByEmail(string email);
}