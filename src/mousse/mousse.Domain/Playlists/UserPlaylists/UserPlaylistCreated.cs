using mousse.Domain.Core.Events;

namespace mousse.Domain.Playlists.UserPlaylists;

public record UserPlaylistCreated(Guid UserId, Guid PlaylistId) : IDomainEvent;
