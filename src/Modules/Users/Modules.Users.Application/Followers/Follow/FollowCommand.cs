using Application.Messaging;

namespace Modules.Users.Application.Followers.Follow;

public record FollowCommand(Guid UserId, Guid FollowedId) : ICommand;
