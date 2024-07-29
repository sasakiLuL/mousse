using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Tracks;

namespace mousse.Domain.Playlists;

public abstract class Playlist : AggregateRoot
{
    public static readonly int MaximalTracksCount = 10000;

    protected readonly List<Track> _traks = [];

    protected Playlist() : base(Guid.NewGuid()) { }

    protected Playlist(
        PlaylistName playlistName,
        PlaylistType playlistType,
        Guid authorId,
        Guid? coverId,
        bool isPublic,
        ICollection<Track> tracks)
        : base(Guid.NewGuid())
    {
        PlaylistName = playlistName;
        PlaylistType = playlistType;
        AuthorId = authorId;
        CoverId = coverId;
        _traks = tracks.ToList();
    }

    public PlaylistName PlaylistName { get; set; }

    public PlaylistType PlaylistType { get; private set; }

    public Guid AuthorId { get; private set; }

    public Guid? CoverId { get; set; }

    public bool IsPublic {  get; set; }

    public int TracksCount => _traks.Count;

    protected int DurationInMinutes => _traks.Sum(t => t.Duration.Seconds);

    public IReadOnlyList<Track> Tracks => _traks.AsReadOnly();

    public virtual Result AddTrack(Track track)
    {
        if (TracksCount > MaximalTracksCount)
        {
            return Result.Failure(PlaylistErrors.TooManyTracks);
        }

        if (_traks.Exists(t => t.Id == track.Id))
        {
            return Result.Failure(PlaylistErrors.TrackAlreadyExist);
        }

        _traks.Add(track);

        return Result.Success();
    }

    public virtual Result RemoveTrack(Track track)
    {
        if (!_traks.Remove(track))
        {
            return Result.Failure(TrackErrors.NotFound);
        }

        return Result.Success();
    }
}
