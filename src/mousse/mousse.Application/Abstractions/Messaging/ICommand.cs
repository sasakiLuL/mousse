using MediatR;
using mousse.Domain.Core.Results;

namespace mousse.Application.Abstractions.Messaging;

public interface ICommandBase {}

public interface ICommand
    : IRequest<Result>, ICommandBase {}

public interface ICommand<TResponce>
    : IRequest<Result<TResponce>>, ICommandBase {}
