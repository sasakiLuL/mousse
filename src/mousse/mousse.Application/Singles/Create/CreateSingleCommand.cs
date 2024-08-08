using mousse.Application.Abstractions.Messaging;
using mousse.Application.Tracks;

namespace mousse.Application.Singles.Create;

public record CreateSingleCommand(
    Guid AuthorId,
    string SingleName,
    bool IsPublic,
    List<TrackRequest> Releases) : ICommand;
