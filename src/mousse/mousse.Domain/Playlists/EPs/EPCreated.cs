using mousse.Domain.Core.Events;
using mousse.Domain.Users;

namespace mousse.Domain.Playlists.EPs;

record class EPCreated(Guid UserId, Guid EPId) : IDomainEvent;
