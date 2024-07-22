using mousse.Domain.Core.Results;
using mousse.Domain.Users;

namespace mousse.Domain.Followers;

public interface IFollowerService
{
    Task<Result<Follower>> StartFollowingAsync(User user, User followed, CancellationToken token = default);
}
