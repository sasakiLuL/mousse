using Microsoft.EntityFrameworkCore;
using Modules.Users.Communication.Users;
using Modules.Users.Persistence;

namespace Modules.Users.Infrastructure.Communication;

public class UserApi(UsersDbContext context) : IUserApi
{
    public async Task<UserResponse?> GetUser(Guid id, CancellationToken token = default)
    {
        return await context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserResponse(u.Id, u.IdentityServiceUserId, u.Email.Value, u.UserName.Value))
            .FirstOrDefaultAsync();
    }
}
