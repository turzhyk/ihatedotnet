using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using IHateDotnet.Contracts;
using IHateDotnet.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserStore.Application.Services;
using UserStore.Core.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] UserCreateRequest request,
        [FromServices] IPasswordHasher<User> passwordHasher)
    {
        // var existing = await _userRepo.GetByEmail(request.Email);
        // if (existing != null)
        //     return BadRequest("User already exists");

        var user = new User(Guid.NewGuid(), request.Email, "", request.Email, UserRole.User, DateTime.UtcNow);
        var hashedPword = passwordHasher.HashPassword(user, request.Password);
        var final = new User(user.Id, user.Email, hashedPword, user.Email, user.Role, user.CreatedAt);
        await _service.CreateUser(final);
        return Ok(user.Id);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> LoginUser([FromBody] UserLoginRequest request,
        [FromServices] IPasswordHasher<User> passwordHasher, TokenProvider tokenProvider)
    {
        var user = await _service.GetByEmail(request.Login);
        if(user == null)
            throw new Exception("user not found");
        
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if(result != PasswordVerificationResult.Success)
            return Unauthorized();
        var token = tokenProvider.Create(user);
        return Ok(token);
    }

    [Authorize]
    [HttpGet("addessesGet")]
    public async Task<ActionResult<List<UserAddressGetDto>>> GetUserAddresses()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            throw new Exception("no active user found");
        }
        var result = await  _service.GetAdressesByUserId(new Guid(userId));
        return Ok(result);
    }
    [Authorize]
    [HttpPost("adressAdd")]
    public async Task<ActionResult> AddUserAdress ([FromBody] UserAdressCreateDto request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            throw new Exception("no active user found");
            // return NotFound();
        }

        await _service.AddUserAdress(userId, request);
        return Ok();
    }
}