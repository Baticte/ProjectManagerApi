using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.Features.Users.Commands.AuthenticateUser;
using ProjectManagerApi.Features.Users.Commands.RegisterUser;

namespace ProjectManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticateUserCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
        {
            return Unauthorized(result.Message);
        }

        return Ok(new { Token = result.Token, Message = result.Message });
    }
    
}