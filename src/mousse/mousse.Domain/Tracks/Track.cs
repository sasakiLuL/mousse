using mousse.Domain.Core.Entities;
using mousse.Domain.Genres;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Domain.Tracks;

public class Track : AggregateRoot
{
    private Track() : base(Guid.NewGuid()) { }

    public TrackName TrackName { get; private set; }

    public Duration Duration { get; private set; }

    public List<Playlist> Playlists { get; private set; }

    public List<User> Artists { get; private set; }

    public List<Genre> Genres { get; private set; }
}
