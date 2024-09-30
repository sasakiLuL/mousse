using Domain.Results;
using Modules.Users.Domain.Users;

namespace Modules.Users.Domain.Followers;

public interface IFollowerService
{
    Task<Result<Follower>> FollowAsync(User user, User followed, CancellationToken token = default);
}