using mousse.Domain.Core.Events;

namespace mousse.Domain.Accesses;

public record AddedCollaborator(Guid PlaylistId, Guid UserId) : IDomainEvent;
