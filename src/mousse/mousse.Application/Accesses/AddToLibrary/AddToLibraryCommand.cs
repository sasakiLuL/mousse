using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Accesses.AddToLibrary;

public record AddToLibraryCommand(
    Guid UserId,
    Guid PlaylistId) : ICommand;
