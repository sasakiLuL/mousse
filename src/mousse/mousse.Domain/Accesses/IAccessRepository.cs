using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Accesses;

public interface IAccessRepository : IRepository<Access>
{
    Task<bool> IsAlreadySavedAsync(Guid userId, Guid playlistId, CancellationToken token = default);

    Task<Access?> GetAsync(Guid userId, Guid playlistId, CancellationToken token = default);

    Task<bool> IsCollaboratorInPlaylistAsync(Guid userId, Guid playlistId, CancellationToken token = default);
}
