using Application.Messaging;

namespace Modules.Users.Application.Users.Update;

public record UpdateUserCommand(Guid UserId, string UserName) : ICommand;
