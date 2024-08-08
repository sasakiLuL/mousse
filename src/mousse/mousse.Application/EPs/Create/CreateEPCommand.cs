using mousse.Application.Abstractions.Messaging;
using mousse.Application.Tracks;

namespace mousse.Application.EPs.Create;

public record CreateEPCommand(
    Guid AuthorId,
    string EPName,
    bool IsPublic,
    List<TrackRequest> Releases) : ICommand;
