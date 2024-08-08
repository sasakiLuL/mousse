using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Users;

namespace mousse.Application.Playlists.RemoveTrack;

public class RemoveTrackFromPlaylistCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IAccessService accessService,
    IPlaylistRepository playlistRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RemoveTrackFromPlaylistCommand>
{
    public async Task<Result> Handle(RemoveTrackFromPlaylistCommand request, CancellationToken token)
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

        if (await accessService.HasRightToChangePlaylistAsync(
                user, playlist, token))
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var track = playlist.Tracks.FirstOrDefault(t => t.Id == request.TrackId);

        if (track is null)
        {
            return Result.Failure(TrackErrors.NotFound);
        }

        var removingResult = playlist.RemoveTrack(track);

        if (removingResult.IsFailure)
        {
            return removingResult;
        }

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
