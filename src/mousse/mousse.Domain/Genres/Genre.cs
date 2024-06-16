using mousse.Domain.Core.Entities;
using mousse.Domain.Tracks;

namespace mousse.Domain.Genres;

public class Genre : Entity
{
    private Genre() : base(Guid.NewGuid()) { }

    public GenreName GenreName { get; private set; }

    public List<Track> Tracks { get; private set; }
}
