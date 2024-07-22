using mousse.Domain.Tags;

namespace mousse.Persistence.Tags;

public class TagRepository(MousseContext context)
    : Repository<Tag>(context), ITagRepository
{
}
