using mousse.Domain.Core.Events;

namespace mousse.Domain.Core.Entities;

public abstract class AggregateRoot : Entity
{
    private readonly List<DomainEvent> _events;

    public AggregateRoot(Guid id) : base(id)
    {
        _events = [];
    }

    public void RaiseDomainEvent(DomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    public IReadOnlyCollection<DomainEvent> DomainEvents { get => _events; }
}
