using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Followers.Unfollow;

public record UnfollowCommand(
    Guid UserId,
    Guid FollowerId) : ICommand;
