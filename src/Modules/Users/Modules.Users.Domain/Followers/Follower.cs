using Domain.Entities;
using Domain.Time;

namespace Modules.Users.Domain.Followers;

public sealed class Follower : AggregateRoot
{
    private Follower() { }

    private Follower(Guid userId, Guid followedId, DateTime createdOnUtc) : base()
    {
        UserId = userId;
        FollowedId = followedId;
        CreatedOnUtc = createdOnUtc;
    }

    public DateTime CreatedOnUtc { get; private set; }

    public Guid UserId { get; private set; }

    public Guid FollowedId { get; private set; }

    public static Follower Create(Guid userId, Guid followedId)
    {
        var follower = new Follower(userId, followedId, SystemTimeProvider.UtcNow());

        return follower;
    }
}
