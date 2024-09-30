namespace mousse.Api.Endpoints.Users;

public static class UsersConstants
{
    public static class Routes
    {
        public const string Base = "users";

        public const string GetById = "{id:guid}";

        public const string Update = "{id:guid}";

        public const string Register = "register";

        public const string Follow = "{userId:guid}/follow/{followedId:guid}";

        public const string Followers = "{userId:guid}/followers";

        public const string Unfollow = "{userId:guid}/unfollow/{followedId:guid}";
    }

    public static readonly string UsersTag = "Users";

    public static readonly string FollowersTag = "Followers";
}
