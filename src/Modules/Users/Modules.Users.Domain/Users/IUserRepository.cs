using Domain.Repositories;

namespace Modules.Users.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(Guid userId, CancellationToken token = default);
}
