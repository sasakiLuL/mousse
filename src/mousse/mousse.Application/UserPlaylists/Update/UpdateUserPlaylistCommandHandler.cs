using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Users;

namespace mousse.Application.UserPlaylists.Update;

public class UpdateAlbumCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IAccessService accessService,
    IPlaylistRepository playlistRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateAlbumCommand>
{
    public async Task<Result> Handle(UpdateAlbumCommand request, CancellationToken token)
    {
        var user = await userRepository.GetByIdAsync(
                userIdentityProvider.GetUserId(), token);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }

        var playlist = await playlistRepository.GetPlaylistByIdAsync(request.PlaylistId, token);

        if (playlist is null)
        {
            return Result.Failure(PlaylistErrors.NotFound);
        }

        if (!await accessService.HasRightToChangePlaylistAsync(
                user, playlist, token))
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var playlistNameResult = PlaylistName.Create(request.PlaylistName);

        if (playlistNameResult.IsFailure)
        {
            return playlistNameResult;
        }

        playlist.PlaylistName = playlistNameResult.Value;

        playlist.IsPublic = request.IsPublic;

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
