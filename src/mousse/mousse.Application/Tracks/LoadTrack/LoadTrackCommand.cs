using Microsoft.AspNetCore.Http;
using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Tracks.LoadTrack;

public record LoadTrackCommand(
    Guid UserId,
    IFormFile Track) : ICommand<AudioFileResponse>;
