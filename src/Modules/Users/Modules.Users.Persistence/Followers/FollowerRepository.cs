using Microsoft.EntityFrameworkCore;
using Modules.Users.Domain.Followers;
using Persistence.Data;

namespace Modules.Users.Persistence.Followers;

public class FollowerRepository(UsersDbContext context) : Repository<Follower>(context), IFollowerRepository
{
    public async Task<Follower?> GetAsync(Guid userId, Guid followedId, CancellationToken token = default)
    {
        return await context.Followers.FirstOrDefaultAsync(
            f => f.UserId == userId && f.FollowedId == followedId,
            token);
    }

    public async Task<bool> IsAlreadyFollowingAsync(Guid userId, Guid followedId, CancellationToken token = default)
    {
        return await context.Followers.AnyAsync(
            f => f.UserId == userId && f.FollowedId == followedId,
            token);
    }
}
