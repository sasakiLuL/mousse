using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Application.Abstractions.Storage;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Application.Playlists.UpdateCover;

public class UpdatePlaylistCoverCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IAccessService accessService,
    IPlaylistRepository playlistRepository,
    IStorageService storageService,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdatePlaylistCoverCommand>
{
    public async Task<Result> Handle(UpdatePlaylistCoverCommand request, CancellationToken token)
    {
        var user = await userRepository.GetByIdAsync(
                userIdentityProvider.GetUserId(), token);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }

        var playlist = await playlistRepository.GetPlaylistByIdAsync(
                request.PlaylistId, token);

        if (playlist is null)
        {
            return Result.Failure(PlaylistErrors.NotFound);
        }

        if (!await accessService.HasRightToChangePlaylistAsync(
                user, playlist, token))
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var coverId = await storageService.UploadFileAsync(
                request.Cover, token);

        playlist.UpdateCover(coverId);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
