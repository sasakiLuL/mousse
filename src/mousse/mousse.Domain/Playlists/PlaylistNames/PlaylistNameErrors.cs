using mousse.Domain.Core.Errors;

namespace mousse.Domain.Playlists.PlaylistNames;

public static class PlaylistNameErrors
{
    public static Error TooLong = new Error(
            "PlaylistName.TooLong", "The playlist name is too long.");

    public static Error InvalidFormat = new Error(
        "PlaylistName.InvalidFormat", "The playlist name contains unacceptable symbols.");
}
