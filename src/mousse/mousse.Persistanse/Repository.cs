using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Repositories;

namespace mousse.Persistence;

public class Repository<TValue>(
    MousseContext context) : IRepository<TValue> 
    where TValue : Entity
{
    protected readonly MousseContext _context = context;

    public async Task AddAsync(TValue entity, CancellationToken token = default)
    {
        await _context.AddAsync(entity, token);
    }

    public void Remove(TValue entity)
    {
        _context.Remove(entity);
    }
}
