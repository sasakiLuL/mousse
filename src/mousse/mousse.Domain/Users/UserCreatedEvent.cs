using mousse.Domain.Core.Events;

namespace mousse.Domain.Users;

public record UserCreatedEvent(Guid UserId) : IDomainEvent;
