using mousse.Domain.Core.Entities;

namespace mousse.Domain.Core.Repositories;

public interface IRepository<TValue> where TValue : Entity
{
    Task<TValue> GetByIdAsync(Guid Id, CancellationToken token = default);

    Task AddAsync(TValue entity, CancellationToken token = default);

    Task RemoveAsync(TValue entity, CancellationToken token = default);
}
