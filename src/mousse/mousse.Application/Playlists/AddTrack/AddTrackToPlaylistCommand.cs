using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Playlists.AddTrack;

public record AddTrackToPlaylistCommand(
    Guid PlaylistId,
    Guid TrackPlaylistId,
    Guid TrackId) : ICommand;
