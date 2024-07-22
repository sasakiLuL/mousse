using mousse.Domain.Core.Events;

namespace mousse.Domain.Playlists.Albums;

public record AlbumCreated(Guid UserId, Guid AlbumId) : IDomainEvent;
