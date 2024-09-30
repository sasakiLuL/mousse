using Application.Messaging;

namespace Modules.Users.Application.Users.GetById;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
