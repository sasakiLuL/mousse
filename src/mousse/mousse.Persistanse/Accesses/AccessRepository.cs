using Microsoft.EntityFrameworkCore;
using mousse.Domain.Accesses;

namespace mousse.Persistence.Accesses;

public class AccessRepository(
    MousseContext context) : Repository<Access>(context), IAccessRepository
{
    public async Task<Access?> GetAsync(Guid userId, Guid playlistId, CancellationToken token = default)
    {
        return await _context.Accesses.FirstOrDefaultAsync(
                a => a.UserId == userId && a.PlaylistId == playlistId,
                token);
    }

    public async Task<bool> IsAlreadySavedAsync(Guid userId, Guid playlistId, CancellationToken token = default)
    {
        return await _context.Accesses.AnyAsync(
            f => f.UserId == userId && f.PlaylistId == playlistId,
            token);
    }

    public async Task<bool> IsCollaboratorInPlaylistAsync(Guid userId, Guid playlistId, CancellationToken token = default)
    {
        return await _context.Accesses.AnyAsync(
            f => f.UserId == userId && f.PlaylistId == playlistId && f.Role == Role.Collaborator,
            token);
    }
}
