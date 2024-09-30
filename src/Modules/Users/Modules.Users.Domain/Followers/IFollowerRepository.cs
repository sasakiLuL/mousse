using Domain.Repositories;

namespace Modules.Users.Domain.Followers;

public interface IFollowerRepository : IRepository<Follower>
{
    Task<bool> IsAlreadyFollowingAsync(Guid userId, Guid followedId, CancellationToken token = default);

    Task<Follower?> GetAsync(Guid userId, Guid followedId, CancellationToken token = default);
}
