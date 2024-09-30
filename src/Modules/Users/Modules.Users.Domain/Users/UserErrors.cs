using Domain.Errors;

namespace Modules.Users.Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid id) => new Error("User.NotFound", $"User with id = {id} was not found.");

    public static readonly Error InvalidUserCredentials = new Error(
        "User.InvalidUserCredentials",
        "Invalid user credentials.");

    public static readonly Error InvalidPermissions = new Error(
        "User.InvalidPermissions",
        "The current user does not have the permissions to perform that operation.");
}
