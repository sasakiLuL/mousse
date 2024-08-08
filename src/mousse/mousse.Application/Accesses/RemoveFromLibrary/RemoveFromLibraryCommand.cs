using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Accesses.RemoveFromLibrary;

public record RemoveFromLibraryCommand(
    Guid UserId,
    Guid PlaylistId) : ICommand;
