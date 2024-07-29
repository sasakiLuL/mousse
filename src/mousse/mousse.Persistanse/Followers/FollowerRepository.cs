using Microsoft.EntityFrameworkCore;
using mousse.Domain.Followers;

namespace mousse.Persistence.Followers;

public class FollowerRepository(MousseContext context)
    : Repository<Follower>(context), IFollowerRepository
{
    public async Task<Follower?> GetAsync(Guid userId, Guid followedId, CancellationToken token = default)
    {
        return await _context.Followers.FirstOrDefaultAsync(
            f => f.UserId == userId && f.FollowedId == followedId,
            token);
    }

    public async Task<bool> IsAlreadyFollowingAsync(Guid userId, Guid followedId, CancellationToken token = default)
    {
        return await _context.Followers.AnyAsync(
            f => f.UserId == userId && f.FollowedId == followedId,
            token);
    }
}
