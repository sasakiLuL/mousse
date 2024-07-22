using mousse.Domain.Core.Errors;

namespace mousse.Domain.Playlists;

public static class PlaylistErrors
{
    public static Error TracksLimit = new Error(
            "Playlist.TracksLimit", "The track limit has been reached.");

    public static Error TrackAlreadyExist = new Error(
        "Playlist.TrackAlreadyExist", "The track is already exist.");

    public static Error TrackNotFound = new Error(
        "Playlist.TrackNotFound", "The track is not found.");
}
