using mousse.Domain.Core.Entities;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Tags.TagNames;

namespace mousse.Domain.Tags;

public sealed class Tag : AggregateRoot
{
    private Tag() : base(Guid.NewGuid()) { }

    private Tag(TagName tagName) : base(Guid.NewGuid())
    {
        TagName = tagName;
    }

    public TagName TagName { get; private set; }
}
