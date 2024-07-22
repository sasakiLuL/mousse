namespace mousse.Application.Abstractions;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken token = default);
}
