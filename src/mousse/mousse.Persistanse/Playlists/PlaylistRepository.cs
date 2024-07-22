using mousse.Domain.Playlists;

namespace mousse.Persistence.Playlists;

public class PlaylistRepository(MousseContext context)
    : Repository<Playlist>(context), IPlaylistRepository
{
}
