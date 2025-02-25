using MediatR;

namespace ProjectManagerApi.Features.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<RegisterUserResult>
{
    public string Username { get; set; } 
    public string Password { get; set; }
}

public class RegisterUserResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}