using Microsoft.EntityFrameworkCore;
using mousse.Domain.Accesses;

namespace mousse.Persistence.Accesses;

public class AccessRepository(
    MousseContext context) : Repository<Access>(context), IAccessRepository
{
    public Task<Access?> GetAsync(Guid userId, Guid playlistId, CancellationToken token = default)
    {
        return _context.Accesses
            .FirstOrDefaultAsync(
                a => a.UserId == userId && 
                a.PlaylistId == playlistId);
    }
}
