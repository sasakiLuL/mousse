using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.UserPlaylists.Update;

public record UpdateAlbumCommand(
    Guid PlaylistId,
    string PlaylistName,
    bool IsPublic) : ICommand;
