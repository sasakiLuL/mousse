using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Domain.Accesses;

public interface IAccessService
{
    Task<Result<Access>> AddPlaylistToLibraryAsync(
        User user, Playlist playlist, CancellationToken token = default);

    Task<bool> HasRightToChangePlaylistAsync(
        User user, Playlist playlist, CancellationToken token = default);
}
