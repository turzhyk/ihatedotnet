using IHateDotnet.Contracts;
using UserStore.Core.Models;

namespace UserStore.Application.Services;

public interface IUserService
{
    Task<Guid> CreateUser(User user);
    Task<User> GetByEmail(string email);
    Task<List<UserAddressGetDto>> GetAdressesByUserId(Guid id);
    Task AddUserAdress(string userId, UserAdressCreateDto dto);
}