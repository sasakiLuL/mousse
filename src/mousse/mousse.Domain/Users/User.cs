using mousse.Domain.Core.Entities;
using mousse.Domain.Playlists;
using mousse.Domain.Tracks;
using System.ComponentModel;

namespace mousse.Domain.Users;

public class User : AggregateRoot
{
    private User() : base(Guid.NewGuid()) { }

    public UserName UserName { get; private set; }

    public List<User> Subscribers { get; set; }

    public List<Track> Tracks { get; set; }

    public List<Playlist> SavedPlaylists { get; set; }

    public List<Playlist> CreatedPlaylists { get; set; }

    public Playlist LikedPlaylist { get; set; }

    public Guid LikedPlaylistId {  get; set; }
}
