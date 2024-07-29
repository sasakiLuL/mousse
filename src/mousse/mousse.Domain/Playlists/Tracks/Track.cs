using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists.Tracks.Durations;
using mousse.Domain.Playlists.Tracks.TrackNames;
using mousse.Domain.Tags;
using mousse.Domain.Users;

namespace mousse.Domain.Playlists.Tracks;

public sealed class Track : Entity
{
    public static readonly int MaximalTagCount = 10;

    private Track() : base(Guid.NewGuid()) { }

    public Track(
        TrackName trackName,
        Duration duration,
        Guid audioId,
        Guid coverId,
        Guid releasePlaylistId,
        ICollection<User> artists,
        ICollection<Tag> tags) : base(Guid.NewGuid())
    {
        TrackName = trackName;
        Duration = duration;
        AudioBlobId = audioId;
        CoverBlobId = coverId;
        ReleasePlaylistId = releasePlaylistId;
        Artists = artists.ToList();
        Tags = tags.ToList();
    }

    public TrackName TrackName { get; private set; }

    public Duration Duration { get; private set; }

    public Guid AudioBlobId { get; private set; }

    public Guid CoverBlobId { get; private set; }

    public Guid ReleasePlaylistId { get; private set; }

    public IReadOnlyList<User> Artists { get; private set; }

    public IReadOnlyList<Tag> Tags { get; private set; }

    public IReadOnlyList<Playlist> Playlists { get; private set; }

    public static Result<Track> Create(
        TrackName trackName,
        Duration duration,
        Guid audioId,
        Guid coverId,
        Guid releasePlaylistId,
        ICollection<User> artists,
        ICollection<Tag> tags)
    {
        if (tags.Count > MaximalTagCount)
        {
            return Result.Failure<Track>(TrackErrors.TooManyTags);
        }

        return Result.Success(
            new Track(
                trackName, 
                duration, 
                audioId,
                coverId, 
                releasePlaylistId, 
                artists, 
                tags));
    }
}
