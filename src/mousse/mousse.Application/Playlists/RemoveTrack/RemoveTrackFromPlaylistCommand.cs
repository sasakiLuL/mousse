using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Playlists.RemoveTrack
{
    public record RemoveTrackFromPlaylistCommand(
        Guid PlaylistId, 
        Guid TrackId) : ICommand;
}
