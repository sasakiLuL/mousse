using mousse.Domain.Core.Errors;

namespace mousse.Domain.Playlists.Tracks;

public static class TrackErrors
{
    public static readonly Error NotFound = new Error(
        "Track.NotFound", "The track was not found.");

    public static readonly Error TooManyTags = new Error(
        "Track.TooManyTags", "The limit of tags has been reached.");

    public static readonly Error TrackSessionNotFound = new Error(
        "Track.TrackSessionNotFound", "The track session was not found.");
}
