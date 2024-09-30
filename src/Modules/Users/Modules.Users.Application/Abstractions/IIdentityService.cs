namespace Modules.Users.Application.Abstractions;

public interface IIdentityService
{
    Task<bool> ExistsAsync(string identityProviderUserId, CancellationToken cancellationToken = default);
}
