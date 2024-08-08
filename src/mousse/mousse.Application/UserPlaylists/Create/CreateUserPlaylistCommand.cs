using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.UserPlaylists.Create;

public record CreateUserPlaylistCommand(
    Guid AuthorId,
    string PlaylistName,
    bool IsPublic) : ICommand;
