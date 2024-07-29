using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Playlists;

public interface IPlaylistRepository : IRepository<Playlist>
{
    Task<Playlist?> GetPlaylistByIdAsync(Guid playlistId, CancellationToken token = default);
}
