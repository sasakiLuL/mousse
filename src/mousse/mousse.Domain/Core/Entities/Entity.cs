namespace mousse.Domain.Core.Entities;

public abstract class Entity
{
    private Entity() { }

    public Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; protected init; }
}
