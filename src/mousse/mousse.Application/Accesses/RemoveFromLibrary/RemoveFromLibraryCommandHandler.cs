using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Users;

namespace mousse.Application.Accesses.RemoveFromLibrary;

public class RemoveFromLibraryCommandHandler(
    IUserIdentityProvider userIdentityProvider,
    IUserRepository userRepository,
    IAccessRepository accessRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveFromLibraryCommand>
{
    public async Task<Result> Handle(RemoveFromLibraryCommand request, CancellationToken token)
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

        accessRepository.Delete(access);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
