using Domain.Results;
using Modules.Users.Domain.Users;

namespace Modules.Users.Domain.Followers;

public class FollowerService(IFollowerRepository followerRepository) : IFollowerService
{
    public async Task<Result<Follower>> FollowAsync(User user, User followed, CancellationToken token = default)
    {
        if (user.Id == followed.Id)
        {
            return Result.Failure<Follower>(FollowerErrors.SameUser);
        }

        if (await followerRepository.IsAlreadyFollowingAsync(user.Id, followed.Id, token))
        {
            return Result.Failure<Follower>(FollowerErrors.AlreadyFollowing);
        }

        var follower = Follower.Create(user.Id, followed.Id);

        return follower;
    }
}
