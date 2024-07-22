using mousse.Domain.Core.Events;

namespace mousse.Domain.Accesses;

public record PlaylistSaved(Guid PlaylistId, Guid UserId) : IDomainEvent;
