using mousse.Domain.Core.Entities;

namespace mousse.Domain.Core.Repositories;

public interface IRepository<TValue> where TValue : Entity
{
    Task AddAsync(TValue entity, CancellationToken token = default);

    void Delete(TValue entity);
}
