using mousse.Domain.Core.Errors;

namespace mousse.Domain.Accesses;

public static class AccessErrors
{
    public static readonly Error AlreadyCollaborator = new Error(
        "Access.AlreadyCollaborator",
        "User is already a collaborator.");

    public static readonly Error AlreadySaved = new Error(
        "Access.AlreadySaved",
        "Playlist is already saved.");
}
