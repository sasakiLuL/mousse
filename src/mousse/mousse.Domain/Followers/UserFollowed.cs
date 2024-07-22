using mousse.Domain.Core.Events;

namespace mousse.Domain.Followers;

public record UserFollowed(Guid UserId, Guid FollowedId) : IDomainEvent;