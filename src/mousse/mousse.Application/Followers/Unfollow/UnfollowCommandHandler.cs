using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Core.Results;
using mousse.Domain.Followers;
using mousse.Domain.Users;

namespace mousse.Application.Followers.Unfollow;

public class UnfollowCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IFollowerRepository followerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UnfollowCommand>
{
    public async Task<Result> Handle(UnfollowCommand request, CancellationToken token)
    {
        var followed = await userRepository.GetByIdAsync(request.FollowerId, token);

        if (followed is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        
        if (followed.Id != userIdentityProvider.GetUserId())
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var follower = await followerRepository.GetAsync(request.UserId, followed.Id, token);

        if (follower is null)
        {
            return Result.Failure(FollowerErrors.NotFoundByUser);
        }

        followerRepository.Delete(follower);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
