using mousse.Application.Abstractions.Messaging;
using mousse.Application.Tracks;

namespace mousse.Application.Albums.Create;

public record CreateAlbumCommand(
    Guid AuthorId,
    string AlbumName,
    bool IsPublic,
    List<TrackRequest> Releases) : ICommand;
