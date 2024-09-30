using Microsoft.EntityFrameworkCore;
using Modules.Users.Domain.Users;
using Persistence.Data;

namespace Modules.Users.Persistence.Users;

public class UserRepository(UsersDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken token = default)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == userId, token);
    }
}
