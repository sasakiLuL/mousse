using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Users;

namespace mousse.Application.Accesses.ChangeRole;

public class ChangeRoleCommandHandler(
    IUserRepository userRepository,
    IAccessRepository accessRepository,
    IUserIdentityProvider userIdentityProvider,
    IUnitOfWork unitOfWork) : ICommandHandler<ChangeRoleCommand>
{
    public async Task<Result> Handle(ChangeRoleCommand request, CancellationToken token)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, token);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }

        if (user.Id != userIdentityProvider.GetUserId())
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var access = await accessRepository.GetAsync(user.Id, request.PlaylistId, token);

        if (access is null)
        {
            return Result.Failure(AccessErrors.NotFoundByPlaylist);
        }

        var changingResult = access.ChangeRole(request.Role);

        if (changingResult.IsFailure)
        {
            return changingResult;
        }

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
