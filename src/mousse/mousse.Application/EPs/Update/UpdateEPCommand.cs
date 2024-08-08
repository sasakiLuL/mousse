using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.EPs.Update;

public record UpdateEPCommand(
    Guid EPId,
    string EPName,
    bool IsPublic) : ICommand;
