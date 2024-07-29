using mousse.Domain.Core.Events;

namespace mousse.Domain.Users;

public record UserCreated(Guid UserId) : IDomainEvent;