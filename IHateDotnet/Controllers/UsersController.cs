using IHateDotnet.Contracts;
using Microsoft.AspNetCore.Mvc;
using UserStore.Application.Services;
using UserStore.Core.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController:ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] UserCreateRequest request)
    {
        
        return Ok(Guid.NewGuid());
    }
}