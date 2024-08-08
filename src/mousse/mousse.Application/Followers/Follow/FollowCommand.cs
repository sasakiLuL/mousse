using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Followers.Follow;

public record FollowCommand(
    Guid UserId,
    Guid FollowedId) : ICommand;
