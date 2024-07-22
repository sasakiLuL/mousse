using mousse.Domain.Core.Repositories;
using mousse.Domain.Users;

namespace mousse.Domain.Followers;

public interface IFollowerRepository : IRepository<Follower>
{
    Task<bool> IsAlreadyFollowingAsync(User user, User followed, CancellationToken token = default);
}
