using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Albums.Update;

public record UpdateAlbumCommand(
    Guid AlbumId,
    string AlbumName,
    bool IsPublic) : ICommand;
