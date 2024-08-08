using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(Guid userId, CancellationToken token = default);

    Task<List<User>> GetByIdsAsync(List<Guid> ids, CancellationToken token = default);
}
