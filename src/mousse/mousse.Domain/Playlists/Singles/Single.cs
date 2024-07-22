using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Tracks;

namespace mousse.Domain.Playlists.Singles;

public sealed class Single : Playlist
{
    private Single() : base() { }

    private Single(
        PlaylistName singleName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks) : base(
            singleName,
            PlaylistType.Single,
            authorId,
            isPublic,
            tracks)
    { }

    public static Single Create(
        PlaylistName singleName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks)
    {
        var release = new Single(
            singleName,
            authorId,
            isPublic,
            tracks);

        release.RaiseDomainEvent(new SingleCreated(authorId, release.Id));

        return release;
    }
}
