namespace mousse.Domain.Core.Errors;

public static class DomainErrors
{
    public static class PlaylistName
    {
        public static Error TooLong = new Error(
            "PlaylistName.TooLong", "The playlist name is too long.");

        public static Error InvalidFormat = new Error(
            "PlaylistName.InvalidFormat", "The playlist name contain unacceptable symbols.");
    }

    public static class Duration
    {
        public static Error LessThanZero = new Error(
            "Duration.LessThanZero", "The duration is less than 0.");
    }

    public static class TrackName
    {
        public static Error TooLong = new Error(
            "TrackName.TooLong", "The name of track is too long.");

        public static Error InvalidFormat = new Error(
            "TrackName.InvalidFormat", "The name of track contain unacceptable symbols.");
    }

    public static class GenreName
    {
        public static Error TooLong = new Error(
            "GenreName.TooLong", "The name of genre is too long.");

        public static Error InvalidFormat = new Error(
            "GenreName.InvalidFormat", "The name of genre contain unacceptable symbols.");
    }

    public static class UserName
    {
        public static Error TooLong = new Error(
            "UserName.TooLong", "The username is too long.");

        public static Error InvalidFormat = new Error(
            "UserName.InvalidFormat", "The username contain unacceptable symbols.");
    }
}
