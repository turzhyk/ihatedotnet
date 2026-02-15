using UserStore.Core.Models;

namespace UserStore.Application.Services;

public interface IUserService
{
    Task<Guid> CreateUser(User user);
    Task<User> GetByEmail(string email);
}