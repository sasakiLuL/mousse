using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Tracks;

namespace mousse.Domain.Playlists.EPs;

public sealed class EP : Playlist
{
    private EP() : base() { }

    private EP(
        PlaylistName epName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks) : base(
            epName,
            PlaylistType.EP,
            authorId,
            isPublic,
            tracks)
    { }

    public static EP Create(
        PlaylistName epName,
        Guid authorId,
        bool isPublic,
        List<Track> tracks)
    {
        var release = new EP(
            epName,
            authorId,
            isPublic,
            tracks);

        release.RaiseDomainEvent(new EPCreated(authorId, release.Id));
        
        return release;
    }
}
