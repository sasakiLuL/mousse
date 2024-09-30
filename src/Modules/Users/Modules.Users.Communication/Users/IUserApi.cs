namespace Modules.Users.Communication.Users;

public interface IUserApi
{
    public Task<UserResponse?> GetUser(Guid id, CancellationToken token = default);
}
