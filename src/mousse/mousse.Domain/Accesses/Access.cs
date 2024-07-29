using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Results;

namespace mousse.Domain.Accesses;

public sealed class Access : AggregateRoot
{
    private Access() : base() { }

    public Access(
        Guid userId,
        Guid playlistId,
        DateTime createdOnUtc) : base()
    {
        UserId = userId;
        PlaylistId = playlistId;
        Role = Role.User;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid UserId { get; private set; }

    public Guid PlaylistId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public Role Role { get; set; }

    public Result ChangeRole(Role role)
    {
        if (Role == role)
        {
            return Result.Failure(AccessErrors.SameRole);
        }

        Role = role;

        if (Role == Role.Collaborator)
        {
            RaiseDomainEvent(new CollaboratorCreated(PlaylistId, UserId));
        }

        return Result.Success();
    }
}
