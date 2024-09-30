using Application.Messaging;

namespace Modules.Users.Application.Followers.GetByUserId;

public record GetFollowersByUserIdQuery(Guid UserId) : IQuery<List<FollowerResponse>>;
