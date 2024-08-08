using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Playlists.Delete;

public record DeletePlaylistCommand(
    Guid PlaylistId) : ICommand;
