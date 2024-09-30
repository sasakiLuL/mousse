namespace Modules.Users.Communication.Users;

public record UserResponse(
    Guid Id,
    Guid IdentityServiceUserId,
    string Email,
    string UserName);
