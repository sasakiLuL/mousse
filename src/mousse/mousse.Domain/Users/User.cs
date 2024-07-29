using mousse.Domain.Core.Entities;
using mousse.Domain.Users.Emails;
using mousse.Domain.Users.UserNames;

namespace mousse.Domain.Users;

public sealed class User : AggregateRoot
{
    private User() : base(Guid.NewGuid()) { }

    public User(
        UserName userName, 
        Email email, 
        Guid likedPlaylistId) : base(Guid.NewGuid())
    {
        UserName = userName;
        Email = email;
        LikedPlaylistId = likedPlaylistId;
    }

    public UserName UserName { get; private set; }

    public Email Email { get; private set; }

    public Guid LikedPlaylistId { get; private set; }

    public User Create(UserName userName, Email email, Guid likedPlaylistId)
    {
        var user = new User(userName, email, likedPlaylistId);

        user.RaiseDomainEvent(new UserCreated(user.Id));

        return user;
    }
}
