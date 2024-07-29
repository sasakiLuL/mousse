using Microsoft.EntityFrameworkCore;
using mousse.Domain.Users;

namespace mousse.Persistence.Users;

public class UserRepository(MousseContext context)
    : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken token = default)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }
}
