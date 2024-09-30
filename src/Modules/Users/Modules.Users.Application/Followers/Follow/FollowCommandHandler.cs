using Application.Authentication;
using Application.Data;
using Application.Messaging;
using Domain.Results;
using Modules.Users.Application.Abstractions;
using Modules.Users.Domain.Followers;
using Modules.Users.Domain.Users;

namespace Modules.Users.Application.Followers.Follow;

public class FollowCommandHandler(
    IUserRepository userRepository,
    IUserCredentialsProvider userCredentialsProvider,
    IFollowerRepository followerRepository, 
    IFollowerService followerService,
    IUnitOfWork unitOfWork) : ICommandHandler<FollowCommand>
{
    public async Task<Result> Handle(FollowCommand request, CancellationToken token)
    {
        var followed = await userRepository.GetByIdAsync(request.FollowedId, token);

        if (followed is null)
        {
            return Result.Failure(UserErrors.NotFound(request.FollowedId));
        }

        if (followed.IdentityServiceUserId != userCredentialsProvider.UserId)
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var user = await userRepository.GetByIdAsync(request.UserId, token);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound(request.UserId));
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
