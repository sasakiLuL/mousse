using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Accesses;

public interface IAccessRepository : IRepository<Access>
{
    Task<Access?> GetAsync(Guid userId, Guid playlistId, CancellationToken token = default);
}
