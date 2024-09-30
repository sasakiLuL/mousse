using Application.Messaging;

namespace Modules.Users.Application.Followers.Unfollow;

public record UnfollowCommand(Guid UserId, Guid FollowerId) : ICommand;
