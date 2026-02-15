using UserStore.Core.Models;
using UserStore.DataAccess.Repos;

namespace UserStore.Application.Services;

public class UserService : IUserService
{
    public readonly IUsersRepository _repo;

    public UserService(IUsersRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> CreateUser(User user) => await _repo.CreateAsync(user);
    
    public async Task<User> GetByEmail(string email) => await _repo.GetByEmail(email);
    
}