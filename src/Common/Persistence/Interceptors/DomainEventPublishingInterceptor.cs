using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Interceptors;

public class DomainEventPublishingInterceptor(IPublisher publisher) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var aggregates = eventData.Context.ChangeTracker
            .Entries<AggregateRoot>()
            .Select(e => e.Entity).ToList();

        var domainEvents = aggregates
            .Select(e => e.DomainEvents)
            .SelectMany(e => e).ToList();

        aggregates.ForEach(a => a.ClearDomainEvents());

        domainEvents.ForEach(e => publisher.Publish(e));

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
