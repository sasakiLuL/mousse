using Microsoft.AspNetCore.Http;
using mousse.Application.Abstractions.Messaging;

namespace mousse.Application.Playlists.UpdateCover;

public record UpdatePlaylistCoverCommand(
    Guid PlaylistId,
    IFormFile Cover) : ICommand;
