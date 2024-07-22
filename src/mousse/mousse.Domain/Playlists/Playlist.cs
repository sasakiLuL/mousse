using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Tracks;

namespace mousse.Domain.Playlists;

public abstract class Playlist : AggregateRoot
{
    protected const int TracksMaximumCount = 10000;

    protected readonly List<Track> _traks = [];

    protected Playlist() : base(Guid.NewGuid()) { }

    protected Playlist(
        PlaylistName playlistName,
        PlaylistType playlistType,
        Guid authorId,
        bool isPublic,
        List<Track> tracks)
        : base(Guid.NewGuid())
    {
        PlaylistName = playlistName;
        PlaylistType = playlistType;
        _traks = tracks;
        AuthorId = authorId;
    }

    public PlaylistName PlaylistName { get; private set; }

    public PlaylistType PlaylistType { get; private set; }

    public Guid AuthorId { get; private set; }

    public bool IsPublic {  get; set; }

    public int TracksCount => Tracks.Count;

    public IReadOnlyList<Track> Tracks => _traks.AsReadOnly();

    public Result AddTrack(Track track)
    {
        if (TracksCount + 1 > TracksMaximumCount)
        {
            return Result.Failure(PlaylistErrors.TracksLimit);
        }

        if (_traks.Contains(track))
        {
            return Result.Failure(PlaylistErrors.TrackAlreadyExist);
        }

        _traks.Add(track);

        return Result.Success();
    }

    public Result RemoveTrack(Track track)
    {
        if (!_traks.Remove(track))
        {
            return Result.Failure(PlaylistErrors.TrackNotFound);
        }

        return Result.Success();
    }
}
