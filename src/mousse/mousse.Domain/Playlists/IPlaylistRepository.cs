using mousse.Domain.Core.Repositories;
using mousse.Domain.Playlists.Releases.Albums;
using mousse.Domain.Playlists.UserPlaylists;

namespace mousse.Domain.Playlists;

public interface IPlaylistRepository : IRepository<Playlist>
{
    Task<Playlist?> GetPlaylistByIdAsync(Guid playlistId, CancellationToken token = default);

    Task<UserPlaylist?> GetUserPlaylistByIdAsync(Guid playlistId, CancellationToken token = default);

    Task<Album?> GetReleaseByIdAsync(Guid playlistId, CancellationToken token = default);

    Task<Album?> GetAlbumByIdAsync(Guid playlistId, CancellationToken token = default);

    Task<Album?> GetEPByIdAsync(Guid playlistId, CancellationToken token = default);

    Task<Album?> GetSingleByIdAsync(Guid playlistId, CancellationToken token = default);
}
