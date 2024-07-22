using mousse.Domain.Core.Errors;

namespace mousse.Domain.Playlists.Tracks.Durations;

public static class DurationErrors
{
    public static Error LessThanZero = new Error(
            "Duration.LessThanZero", "The duration is less than 0.");
}
