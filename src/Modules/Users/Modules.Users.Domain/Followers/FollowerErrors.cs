using Domain.Errors;

namespace Modules.Users.Domain.Followers;

public static class FollowerErrors
{
    public static readonly Error NotFound = new("Follower.NotFound", "Follow was not found.");

    public static readonly Error SameUser = new("Follower.SameUser", "Can't follow yourself.");

    public static readonly Error AlreadyFollowing = new("Follower.AlreadyFollowing", "Already following.");
}
