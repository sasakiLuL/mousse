using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Core.Results;
using mousse.Domain.Followers;
using mousse.Domain.Users;

namespace mousse.Application.Followers.Follow;

public class FollowCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IFollowerRepository followerRepository,
    IFollowerService followerService,
    IUnitOfWork unitOfWork) : ICommandHandler<FollowCommand>
{
    public async Task<Result> Handle(FollowCommand request, CancellationToken token)
    {
        var followed = await userRepository.GetByIdAsync(request.FollowedId, token);

        if (followed is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }

        if (followed.Id != userIdentityProvider.GetUserId())
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var user = await userRepository.GetByIdAsync(request.UserId, token);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }

        var followingResult = await followerService.FollowAsync(user, followed, token);

        if (followingResult.IsFailure)
        {
            return followingResult;
        }

        await followerRepository.AddAsync(followingResult.Value, token);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
