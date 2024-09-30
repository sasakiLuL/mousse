using Application.Authentication;
using Application.Data;
using Application.Messaging;
using Domain.Results;
using Modules.Users.Application.Abstractions;
using Modules.Users.Domain.Followers;
using Modules.Users.Domain.Users;

namespace Modules.Users.Application.Followers.Unfollow;

public class UnfollowCommandHandler(
    IUserRepository userRepository,
    IUserCredentialsProvider userCredentialsProvider,
    IFollowerRepository followerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UnfollowCommand>
{
    public async Task<Result> Handle(UnfollowCommand request, CancellationToken token)
    {
        var followed = await userRepository.GetByIdAsync(request.FollowerId, token);

        if (followed is null)
        {
            return Result.Failure(UserErrors.NotFound(request.FollowerId));
        }

        if (followed.IdentityServiceUserId != userCredentialsProvider.UserId)
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var follow = await followerRepository.GetAsync(request.UserId, followed.Id, token);

        if (follow is null)
        {
            return Result.Failure(FollowerErrors.NotFound);
        }

        followerRepository.Delete(follow);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
