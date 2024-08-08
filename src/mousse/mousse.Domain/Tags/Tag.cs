using mousse.Domain.Core.Entities;
using mousse.Domain.Playlists.Tracks;
using mousse.Domain.Tags.TagNames;

namespace mousse.Domain.Tags;

public sealed class Tag : AggregateRoot
{
    private Tag() : base(Guid.NewGuid()) { }

    public Tag(Guid id, TagName tagName) : base(id)
    {
        TagName = tagName;
    }

    public TagName TagName { get; private set; }
}
