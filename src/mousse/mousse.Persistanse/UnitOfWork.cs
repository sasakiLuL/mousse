using mousse.Domain.Core.Repositories;

namespace mousse.Persistence;

public class UnitOfWork(MousseContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        return await context.SaveChangesAsync(token);
    }
}
