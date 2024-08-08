using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Users;

namespace mousse.Application.Playlists.Delete;

public class DeletePlaylistCommandHandler(
    IUserIdentityProvider userIdentityProvider,
    IPlaylistRepository playlistRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeletePlaylistCommand>
{
    public async Task<Result> Handle(DeletePlaylistCommand request, CancellationToken token)
    {
        var playlist = await playlistRepository.GetPlaylistByIdAsync(
                request.PlaylistId, token);

        if (playlist is null)
        {
            return Result.Failure(PlaylistErrors.NotFound);
        }

        if (playlist.AuthorId != userIdentityProvider.GetUserId())
        {
            return Result.Failure(UserErrors.NotFound);
        }

        playlistRepository.Delete(playlist);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
