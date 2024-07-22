using mousse.Domain.Core.Entities;
using mousse.Domain.Playlists.Tracks.Durations;
using mousse.Domain.Playlists.Tracks.TrackNames;
using mousse.Domain.Tags;

namespace mousse.Domain.Playlists.Tracks;

public sealed class Track : Entity
{
    private Track() : base(Guid.NewGuid()) { }

    private Track(
        TrackName trackName,
        Duration duration,
        List<Tag> tags) : base(Guid.NewGuid())
    {
        TrackName = trackName;
        Duration = duration;
        Tags = tags;
    }

    public TrackName TrackName { get; private set; }

    public Duration Duration { get; private set; }

    public static Track Create(
        TrackName trackName,
        Duration duration,
        List<Tag> tags)
    {
        var track = new Track(trackName, duration, tags);

        return track;
    }

    public IReadOnlyList<Tag> Tags { get; private set; }

    public IReadOnlyList<Playlist> Playlists { get; private set; }
}
