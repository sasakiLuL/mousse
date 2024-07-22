using mousse.Domain.Core.Errors;

namespace mousse.Domain.Playlists.Tracks.TrackNames;

public static class TrackNameErrors
{
    public static Error TooLong = new Error(
            "TrackName.TooLong", "The name of track is too long.");

    public static Error InvalidFormat = new Error(
        "TrackName.InvalidFormat", "The name of track contains unacceptable symbols.");
}
