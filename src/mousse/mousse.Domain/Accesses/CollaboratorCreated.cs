using mousse.Domain.Core.Events;

namespace mousse.Domain.Accesses;

public record CollaboratorCreated(Guid PlaylistId, Guid UserId) : IDomainEvent;