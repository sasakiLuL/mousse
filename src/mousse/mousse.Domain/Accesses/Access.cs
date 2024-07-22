using mousse.Domain.Core.Entities;

namespace mousse.Domain.Accesses;

public sealed class Access : AggregateRoot
{
    public Access() : base() { }

    public Access(
        Guid userId,
        Guid playlistId,
        AccessLevel accessLevel,
        DateTime createdOnUtc) : base()
    {
        UserId = userId;
        PlaylistId = playlistId;
        AccessLevel = accessLevel;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid UserId { get; private set; }

    public Guid PlaylistId { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public AccessLevel AccessLevel { get; set; }

    public static Access CreateSave(
        Guid userId,
        Guid playlistId,
        DateTime createdOnUtc)
    {
        var access = new Access(
            userId,
            playlistId,
            AccessLevel.Save,
            createdOnUtc);

        access.RaiseDomainEvent(new PlaylistSaved(playlistId, userId));

        return access;
    }

    public static Access CreateCollaboration(
        Guid userId,
        Guid playlistId,
        DateTime createdOnUtc)
    {
        var access = new Access(
            userId,
            playlistId,
            AccessLevel.Collaborator,
            createdOnUtc);

        access.RaiseDomainEvent(new AddedCollaborator(playlistId, userId));

        return access;
    }
}
