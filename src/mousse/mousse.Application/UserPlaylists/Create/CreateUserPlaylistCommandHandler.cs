using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.UserPlaylists;
using mousse.Domain.Users;

namespace mousse.Application.UserPlaylists.Create;

public class CreateAlbumCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IPlaylistRepository playlistRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateUserPlaylistCommand>
{
    public async Task<Result> Handle(CreateUserPlaylistCommand request, CancellationToken token)
    {
        var author = await userRepository.GetByIdAsync(request.AuthorId, token);

        if (author is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }

        if (author.Id != userIdentityProvider.GetUserId())
        {
            return Result.Failure(UserErrors.InvalidPermissions);
        }

        var playlistNameResult = PlaylistName.Create(request.PlaylistName);

        if (playlistNameResult.IsFailure)
        {
            return playlistNameResult;
        }

        await playlistRepository.AddAsync(UserPlaylist.Create(
                Guid.NewGuid(), playlistNameResult.Value, author.Id, request.IsPublic),
                token);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }
}
