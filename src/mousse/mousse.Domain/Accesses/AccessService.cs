using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Domain.Accesses;

public class AccessService(
    IAccessRepository accessRepository) : IAccessService
{
    public async Task<Result<Access>> StartAddingCollaboratorAsync(
        User user, 
        Playlist playlist, 
        CancellationToken token = default)
    {
        var access = await accessRepository.GetAsync(user.Id, playlist.Id);

        if (access is null)
        {
            return Result.Success(
                Access.CreateCollaboration(
                    user.Id, 
                    playlist.Id,
                    DateTime.UtcNow));
        }

        if (access.AccessLevel == AccessLevel.Collaborator)
        {
            return Result.Failure<Access>(AccessErrors.AlreadyCollaborator);
        }

        access.AccessLevel = AccessLevel.Collaborator;

        return Result.Success(access);
    }

    public async Task<Result<Access>> StartSavingAsync(
        User user, 
        Playlist playlist, 
        CancellationToken token = default)
    {
        var access = await accessRepository.GetAsync(user.Id, playlist.Id);

        if (access is not null)
        {
            return Result.Failure<Access>(AccessErrors.AlreadySaved);
        }

        return Result.Success(
            Access.CreateSave(
                user.Id,
                playlist.Id,
                DateTime.UtcNow));
    }
}
