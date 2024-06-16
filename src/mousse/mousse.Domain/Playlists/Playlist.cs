using mousse.Domain.Core.Entities;
using mousse.Domain.Tracks;
using mousse.Domain.Users;

namespace mousse.Domain.Playlists;

public class Playlist : AggregateRoot
{
    private Playlist() : base(Guid.NewGuid()) { }

    public PlaylistName PlaylistName { get; private set; }

    public Duration Duration { get; private set; }

    public PlaylistType PlaylistType { get; private set; }

    public List<Track> Tracks { get; private set; }

    public List<User> Owners { get; private set; }

    public List<User> Users { get; private set; }
}
