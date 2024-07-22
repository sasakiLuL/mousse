using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Domain.Accesses;

internal interface IAccessService
{
    Task<Result<Access>> StartSavingAsync(
        User user, 
        Playlist playlist, 
        CancellationToken token = default);

    Task<Result<Access>> StartAddingCollaboratorAsync(
        User user, 
        Playlist playlist, 
        CancellationToken token = default);
}
