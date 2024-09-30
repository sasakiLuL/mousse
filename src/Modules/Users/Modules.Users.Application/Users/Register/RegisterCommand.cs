using Application.Messaging;

namespace Modules.Users.Application.Users.Register;

public record RegisterCommand(string Email, string UserName) : ICommand;
