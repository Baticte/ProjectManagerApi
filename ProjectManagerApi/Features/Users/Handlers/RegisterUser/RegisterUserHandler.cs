using MediatR;
using ProjectManagerApi.Features.Infrastructure.Repositories;
using ProjectManagerApi.Features.Users.Commands.RegisterUser;
using ProjectManagerApi.Features.Users.Models;

namespace ProjectManagerApi.Features.Users.Handlers.RegisterUser;

public class RegisterUserHandler(IUserRepository userRepository)
    : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
        if (existingUser != null)
        {
            return new RegisterUserResult
            {
                Success = false,
                Message = "User already exists!"
            };
        }

        var user = new User
        {
            UserName = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        
        await _userRepository.AddUserAsync(user, cancellationToken);
        return new RegisterUserResult
        {
            Success = true,
            Message = "User registered successfully!"
        };
    }
}