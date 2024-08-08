using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Accesses;

namespace mousse.Application.Accesses.ChangeRole;

public record ChangeRoleCommand(
    Guid PlaylistId,
    Guid UserId,
    Role Role) : ICommand;
