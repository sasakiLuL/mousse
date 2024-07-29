using mousse.Domain.Playlists.PlaylistNames;

namespace mousse.Domain.Playlists.UserPlaylists;

public sealed class UserPlaylist : Playlist
{
    private UserPlaylist() : base() { }

    private UserPlaylist(
        PlaylistName playlistName,
        Guid authorId,
        Guid? coverId,
        bool isPublic) : base(
            playlistName,
            PlaylistType.Playlist,
            authorId,
            coverId,
            isPublic,
            [])
    { }

    public static UserPlaylist Create(
        PlaylistName playlistName,
        Guid authorId,
        bool isPublic)
    {
        var userPlaylist = new UserPlaylist(
            playlistName, 
            authorId, 
            null, 
            isPublic);

        userPlaylist.RaiseDomainEvent(new UserPlaylistCreated(authorId, userPlaylist.Id));

        return userPlaylist;
    }
}
