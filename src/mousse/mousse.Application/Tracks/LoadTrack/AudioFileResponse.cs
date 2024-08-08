namespace mousse.Application.Tracks.LoadTrack;

public record AudioFileResponse(
    Guid BlobId,
    int Duration);