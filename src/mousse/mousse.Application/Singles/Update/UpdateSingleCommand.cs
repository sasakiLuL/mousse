using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Singles.Update;

public record UpdateSingleCommand(
    Guid SingleId,
    string SingleName,
    bool IsPublic) : ICommand;
