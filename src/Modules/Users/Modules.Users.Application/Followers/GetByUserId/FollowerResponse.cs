namespace Modules.Users.Application.Followers.GetByUserId;

public record FollowerResponse(
    Guid FollowerId, 
    string UserName, 
    DateTime FollowedOnUtc);
