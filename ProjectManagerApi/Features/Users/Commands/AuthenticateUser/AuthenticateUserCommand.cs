using MediatR;

namespace ProjectManagerApi.Features.Users.Commands.AuthenticateUser;

public class AuthenticateUserCommand : IRequest<AuthenticateUserResult>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class AuthenticateUserResult
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string Message { get; set; }
}