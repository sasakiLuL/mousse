using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Accesses;

public interface IAccessRepository : IRepository<Access>
{
    Task<Access?> GetAsync(Guid UserId, Guid playlistId, CancellationToken token = default);
}
