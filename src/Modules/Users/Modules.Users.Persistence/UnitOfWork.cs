using Application.Data;

namespace Modules.Users.Persistence;

public class UnitOfWork(UsersDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        return await context.SaveChangesAsync(token);
    }
}
