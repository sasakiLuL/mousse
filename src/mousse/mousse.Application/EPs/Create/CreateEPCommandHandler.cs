using mousse.Application.Abstractions.Authentication;
using mousse.Application.Abstractions.Data;
using mousse.Application.Abstractions.Messaging;
using mousse.Application.Tracks;
using mousse.Domain.Core.Results;
using mousse.Domain.Playlists;
using mousse.Domain.Playlists.PlaylistNames;
using mousse.Domain.Playlists.Releases.EPs;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Playlists.Tracks.Durations;
using mousse.Domain.Playlists.Tracks.TrackNames;
using mousse.Domain.Tags;
using mousse.Domain.Users;

namespace mousse.Application.EPs.Create;

public class CreateSingleCommandHandler(
    IUserRepository userRepository,
    IUserIdentityProvider userIdentityProvider,
    IPlaylistRepository playlistRepository,
    ITagRepository tagRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateEPCommand>
{
    public async Task<Result> Handle(CreateEPCommand request, CancellationToken token)
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

        var epId = Guid.NewGuid();

        var playlistNameResult = PlaylistName.Create(request.EPName);

        if (playlistNameResult.IsFailure)
        {
            return playlistNameResult;
        }

        List<Result<Track>> releasesResults = [];

        foreach (var r in request.Releases)
        {
            releasesResults.Add(await CreateTrackFromRequestAsync(r, epId, token));
        }

        var releasesCreationResult = Result.AllFailuresOrSuccess(
                releasesResults.ToArray());

        if (releasesCreationResult.IsFailure)
        {
            return releasesCreationResult;
        }

        var epResult = EP.Create(
                epId,
                playlistNameResult.Value,
                author.Id,
                request.IsPublic,
                releasesResults.Select(r => r.Value).ToList());

        if (epResult.IsFailure)
        {
            return epResult;
        }

        await playlistRepository.AddAsync(epResult.Value, token);

        await unitOfWork.SaveChangesAsync(token);

        return Result.Success();
    }

    private async Task<Result<Track>> CreateTrackFromRequestAsync(
        TrackRequest trackRequest, Guid epId, CancellationToken token = default)
    {
        var trackNameResult = TrackName.Create(trackRequest.TrackName);

        var durationResult = Duration.Create(trackRequest.Duration);

        var validationResults = Result.AllFailuresOrSuccess(
                trackNameResult, durationResult);

        if (validationResults.IsFailure)
        {
            return Result.Failure<Track>(validationResults.Errors);
        }

        var artists = await userRepository.GetByIdsAsync(trackRequest.Artists, token);

        if (artists.Count != trackRequest.Artists.Count)
        {
            return Result.Failure<Track>(UserErrors.NotFound);
        }

        var tags = await tagRepository.GetByIdsAsync(trackRequest.Tags, token);

        if (tags.Count != trackRequest.Tags.Count)
        {
            return Result.Failure<Track>(TagErrors.NotFound);
        }

        return Track.Create(
                Guid.NewGuid(),
                trackNameResult.Value,
                durationResult.Value,
                trackRequest.AudioBlobId,
                null,
                epId,
                artists,
                tags);
    }
}
