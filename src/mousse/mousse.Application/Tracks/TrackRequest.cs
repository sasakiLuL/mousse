using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Tracks;

public record TrackRequest(
    Guid AudioBlobId,
    int Duration,
    Guid PlaylistId,
    string TrackName,
    List<Guid> Artists,
    List<Guid> Tags) : ICommand;
