using mousse.Domain.Core.Entities;

namespace mousse.Domain.Followers;

public sealed class Follower : AggregateRoot
{
    private Follower() { }

    private Follower(
        Guid userId,
        Guid followedId,
        DateTime createdOnUtc)
    {
        UserId = userId;
        FollowedId = followedId;
        CreatedOnUtc = createdOnUtc;
    }

    public DateTime CreatedOnUtc { get; private set; }

    public Guid UserId { get; private set; }

    public Guid FollowedId { get; private set; }

    public static Follower Create(
        Guid userId,
        Guid followedId,
        DateTime createdOnUtc)
    {
        var follower = new Follower(userId, followedId, createdOnUtc);

        follower.RaiseDomainEvent(new UserFollowed(userId, followedId));

        return follower;
    }
}
