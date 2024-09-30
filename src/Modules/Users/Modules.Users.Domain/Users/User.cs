using Domain.Entities;
using Modules.Users.Domain.Users.Emails;
using mousse.Domain.Users.UserNames;

namespace Modules.Users.Domain.Users;

public class User : AggregateRoot
{
    private User() : base() {}

    private User(Guid id, Guid identityServiceUserId, Guid likedPlaylistId, Email email, UserName userName) : base(id)
    {
        LikedPlaylistId = likedPlaylistId;
        IdentityServiceUserId = identityServiceUserId;
        Email = email;
        UserName = userName;
    }

    public static User Create(Guid id, Guid identityServiceUserId, Guid likedPlaylistId, Email email, UserName userName)
    {
        return new User(id, identityServiceUserId, likedPlaylistId, email, userName);
    }

    public Guid LikedPlaylistId { get; private set; }

    public Guid IdentityServiceUserId { get; private set; }

    public Email Email { get; private set; }

    public UserName UserName { get; set; }
}
