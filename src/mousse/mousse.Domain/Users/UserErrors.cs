using mousse.Domain.Core.Errors;

namespace mousse.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new Error(
        "User.NotFound",
        "The user with specified id was not found.");

    public static Error InvalidPermissions => new Error(
        "User.InvalidPermissions",
        "The current user does not have the permissions to perform that operation.");
}
