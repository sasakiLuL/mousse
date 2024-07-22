using mousse.Domain.Core.Events;
using mousse.Domain.Users;

namespace mousse.Domain.Playlists.Singles;

public record SingleCreated(Guid UserId, Guid SingleId) : IDomainEvent;
