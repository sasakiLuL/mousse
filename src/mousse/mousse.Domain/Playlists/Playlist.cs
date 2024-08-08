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
        Guid id,
        PlaylistName playlistName,
        PlaylistType playlistType,
        Guid authorId,
        Guid? coverId,
        bool isPublic,
        List<Track> tracks) : base(id)
    {
        PlaylistName = playlistName;
        PlaylistType = playlistType;
        AuthorId = authorId;
        CoverBlobId = coverId;
        _traks = tracks;
    }

    public PlaylistName PlaylistName { get; set; }

    public PlaylistType PlaylistType { get; private set; }

    public Guid AuthorId { get; private set; }

    public Guid? CoverBlobId { get; private set; }

    public bool IsPublic {  get; set; }

    public int TracksCount => _traks.Count;

    protected int DurationInSeconds => _traks.Sum(t => t.Duration.Seconds);

    public IReadOnlyList<Track> Tracks => _traks.AsReadOnly();

    public virtual void UpdateCover(Guid blobId)
    {
        CoverBlobId = blobId;
    }

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
