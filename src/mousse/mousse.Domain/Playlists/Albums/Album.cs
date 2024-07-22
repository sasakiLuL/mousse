using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Users;

namespace mousse.Domain.Playlists.Albums;

public sealed class Album : Playlist
{
    private Album() : base() { }

    private Album(
        PlaylistName albumName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks) : base(
            albumName,
            PlaylistType.Album,
            authorId,
            isPublic,
            tracks)
    { }

    public static Album Create(
        PlaylistName albumName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks)
    {
        var release = new Album(
            albumName,
            authorId,
            isPublic,
            tracks);

        release.RaiseDomainEvent(new AlbumCreated(authorId, release.Id));

        return release;
    }
}
