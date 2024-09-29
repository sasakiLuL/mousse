namespace Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity() { }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; protected init; }

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        return ReferenceEquals(this, other) || Id == other.Id;
    }
}

