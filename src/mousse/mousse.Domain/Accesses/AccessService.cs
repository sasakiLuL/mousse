using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Domain.Accesses;

public class AccessService(
    IAccessRepository accessRepository) : IAccessService
{
    public async Task<Result<Access>> AddPlaylistToLibraryAsync(
        User user, Playlist playlist, CancellationToken token = default)
    {
        if (await accessRepository.IsAlreadySavedAsync(
                user.Id, playlist.Id, token))
        {
            return Result.Failure<Access>(AccessErrors.AlreadySaved);
        }

        if (!playlist.IsPublic)
        {
            return Result.Failure<Access>(PlaylistErrors.NonPublicPlaylist);
        }

        return Result.Success(
            new Access(user.Id, playlist.Id, DateTime.UtcNow));
    }

    public async Task<bool> HasRightToChangePlaylistAsync(
        User user, Playlist playlist, CancellationToken token = default)
    {
        if (playlist.AuthorId != user.Id)
        {
            return false;
        }

        if (!await accessRepository.IsCollaboratorInPlaylistAsync(
                user.Id, playlist.Id, token))
        {
            return false;
        }

        return true;
    }
}
