using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Tracks;

namespace mousse.Domain.Playlists.UserPlaylists;

public sealed class UserPlaylist : Playlist
{
    private UserPlaylist() : base() { }

    private UserPlaylist(
        PlaylistName playlistName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks) : base(
            playlistName,
            PlaylistType.Playlist,
            authorId,
            isPublic,
            tracks)
    { }

    public static UserPlaylist Create(
        PlaylistName playlistName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks)
    {
        var userPlaylist = new UserPlaylist(playlistName, authorId, isPublic, tracks);

        userPlaylist.RaiseDomainEvent(new UserPlaylistCreated(authorId, userPlaylist.Id));

        return userPlaylist;
    }
}
