using Microsoft.EntityFrameworkCore;
using mousse.Domain.Followers;

namespace mousse.Persistence.Followers;

public class FollowerRepository(MousseContext context)
    : Repository<Follower>(context), IFollowerRepository
{
    public Task<bool> IsAlreadyFollowingAsync(Guid userId, Guid followedId, CancellationToken token = default)
    {
        return _context.Followers.AnyAsync(
            f => f.UserId == userId && f.FollowedId == followedId,
            token);
    }
}
