using mousse.Domain.Core.Events;

namespace mousse.Domain.Core.Entities;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _events;

    protected AggregateRoot() : base()
    {
        _events = [];
    }

    public AggregateRoot(Guid id) : base(id)
    {
        _events = [];
    }

    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> DomainEvents => _events.AsReadOnly();
}
