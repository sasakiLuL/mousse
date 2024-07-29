using mousse.Domain.Core.Errors;

namespace mousse.Domain.Playlists;

public static class PlaylistErrors
{
    public static Error NonPublicPlaylist = new Error(
        "Playlist.InvalidPermission", "The playlist is private.");

    public static Error WrongImageFormat = new Error(
        "Playlist.WrongImageFormat", "The image format is not supported.");

    public static Error WrongAudioFormat = new Error(
        "Playlist.WrongAudioFormat", "The audio format is not supported.");

    public static Error NotFound = new Error(
        "Playlist.NotFound", "The playlist with specified id was not found.");

    public static Error TooManyTracks = new Error(
        "Playlist.TooManyTracks", "The track limit has been reached.");

    public static Error TrackAlreadyExist = new Error(
        "Playlist.TrackAlreadyExist", "The track is already exist.");

    
}
