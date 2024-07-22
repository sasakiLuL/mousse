using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Followers;

public interface IFollowerRepository : IRepository<Follower>
{
    Task<bool> IsAlreadyFollowingAsync(Guid userId, Guid followedId, CancellationToken token = default);
}
