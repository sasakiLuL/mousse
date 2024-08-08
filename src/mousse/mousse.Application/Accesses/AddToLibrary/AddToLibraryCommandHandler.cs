using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Application.Accesses.AddToLibrary;

public class AddToLibraryCommandHandler(
    IUserRepository userRepository,
    IPlaylistRepository playlistRepository,
    IAccessRepository accessRepository,
    IAccessService accessService,
    IUserIdentityProvider userIdentityProvider,
    IUnitOfWork unitOfWork) : ICommandHandler<AddToLibraryCommand>
{
    public async Task<Result> Handle(AddToLibraryCommand request, CancellationToken token)
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

        var playlist = await playlistRepository.GetPlaylistByIdAsync(request.PlaylistId, token);

        if (playlist is null)
        {
            return Result.Failure(PlaylistErrors.NotFound);
        }

        var accessResult = await accessService.AddPlaylistToLibraryAsync(user, playlist, token);

        if (accessResult.IsFailure)
        {
            return accessResult;
        }

        await accessRepository.AddAsync(accessResult.Value, token);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
