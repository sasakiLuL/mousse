using mousse.Domain.Core.Errors;

namespace mousse.Domain.Accesses;

public static class AccessErrors
{
    public static readonly Error NotFoundByPlaylist = new Error(
        "Access.NotFoundByPlaylist",
        "The user has no access to specified playlist.");

    public static readonly Error SameRole = new Error(
        "Access.SameRole",
        "The user is already in this role.");

    public static readonly Error AlreadySaved = new Error(
        "Access.AlreadySaved",
        "The playlist is already saved.");
}
