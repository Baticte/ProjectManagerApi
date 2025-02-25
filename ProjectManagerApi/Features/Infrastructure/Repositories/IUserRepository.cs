using ProjectManagerApi.Features.Users.Models;

namespace ProjectManagerApi.Features.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username);
    Task AddUserAsync(User user, CancellationToken cancellationToken);
    Task<IEnumerable<User>> GetAllUsersAsync();
}