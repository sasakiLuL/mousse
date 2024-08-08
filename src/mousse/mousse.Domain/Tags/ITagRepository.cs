using mousse.Domain.Core.Repositories;

namespace mousse.Domain.Tags;

public interface ITagRepository : IRepository<Tag>
{
    Task<Tag?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<List<Tag>> GetByIdsAsync(List<Guid> ids, CancellationToken token = default);
}
