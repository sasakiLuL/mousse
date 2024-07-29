using Microsoft.EntityFrameworkCore;
using mousse.Domain.Playlists;

namespace mousse.Persistence.Playlists;

public class PlaylistRepository(MousseContext context)
    : Repository<Playlist>(context), IPlaylistRepository
{
    public async Task<Playlist?> GetPlaylistByIdAsync(Guid playlistId, CancellationToken token = default)
    {
        return await _context.Playlists.Include(p => p.Tracks)
            .FirstOrDefaultAsync(p => p.Id == playlistId, token);
    }
}
