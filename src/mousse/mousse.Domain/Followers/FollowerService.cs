using mousse.Domain.Core.Results;
using mousse.Domain.Users;

namespace mousse.Domain.Followers;

public class FollowerService(
    IFollowerRepository followerRepository) : IFollowerService
{
    public async Task<Result<Follower>> StartFollowingAsync(
        User user,
        User followed,
        CancellationToken token = default)
    {
        if (user.Id == followed.Id)
        {
            return Result.Failure<Follower>(FollowerErrors.SameUser);
        }

        if (await followerRepository.IsAlreadyFollowingAsync(user, followed, token))
        {
            return Result.Failure<Follower>(FollowerErrors.AlreadyFollowing);
        }

        var follower = Follower.Create(user.Id, followed.Id, DateTime.UtcNow);

        return follower;
    }
}
