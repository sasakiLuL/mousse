using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Users;

namespace mousse.Application.Playlists.AddTrack;

public class AddTrackToPlaylistCommandHandler(
    IUserIdentityProvider userIdentityProvider,
    IUserRepository userRepository,
    IAccessService accessService,
    IPlaylistRepository playlistRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<AddTrackToPlaylistCommand>
{
    public async Task<Result> Handle(AddTrackToPlaylistCommand request, CancellationToken token)
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

        var trackPlaylist = await playlistRepository.GetPlaylistByIdAsync(
                request.TrackPlaylistId, token);

        if (trackPlaylist is null)
        {
            return Result.Failure(PlaylistErrors.NotFound);
        }

        var track = trackPlaylist.Tracks.FirstOrDefault(
                track => track.Id == request.TrackId);

        if (track is null)
        {
            return Result.Failure(TrackErrors.NotFound);
        }

        var addingResult = playlist.AddTrack(track);

        if (addingResult.IsFailure)
        {
            return addingResult;
        }

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
