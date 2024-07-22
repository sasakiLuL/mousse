using mousse.Domain.Core.Errors;

namespace mousse.Domain.Followers;

public static class FollowerErrors
{
    public static readonly Error SameUser = new Error(
        "Follower.SameUser",
        "Can't follow yourself");

    public static readonly Error AlreadyFollowing = new Error(
        "Follower.AlreadyFollowing",
        "Already following");
}
