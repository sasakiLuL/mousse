namespace Modules.Users.Application.Users.GetById;

public record UserResponse(Guid UserId, string Email, string UserName);
