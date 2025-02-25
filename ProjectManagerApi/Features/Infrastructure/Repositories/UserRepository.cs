using MongoDB.Driver;
using ProjectManagerApi.Features.Users.Models;

namespace ProjectManagerApi.Features.Infrastructure.Repositories;

public class UserRepository(IMongoDatabase database) : IUserRepository
{
    private readonly IMongoCollection<User> _users = database.GetCollection<User>("users");

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _users.Find(x => x.UserName == username).FirstOrDefaultAsync();
    }

    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await _users.InsertOneAsync(user, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }
}