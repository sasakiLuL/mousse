using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class Repository<TValue> : IRepository<TValue>
    where TValue : Entity
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TValue entity, CancellationToken token = default)
    {
        await _context.AddAsync(entity, token);
    }

    public void Delete(TValue entity)
    {
        _context.Remove(entity);
    }
}
