using mousse.Application.Abstractions.DurationProviders;
using mousse.Application.Abstractions.Messaging;
using mousse.Application.Abstractions.Storage;
using mousse.Domain.Core.Results;

namespace mousse.Application.Tracks.LoadTrack;

public class LoadTrackCommandHandler(
    IStorageService storageService,
    IDurationProvider trackDurationProvider) : ICommandHandler<LoadTrackCommand, AudioFileResponse>
{
    public async Task<Result<AudioFileResponse>> Handle(LoadTrackCommand request, CancellationToken token)
    {
        var trackBlobId = await storageService.UploadFileAsync(request.Track, token);

        var duration = await trackDurationProvider.GetTrackDurrationInSecondsAsync(
                request.Track.OpenReadStream(), token);

        return Result.Success(new AudioFileResponse(trackBlobId, duration));
    }
}
