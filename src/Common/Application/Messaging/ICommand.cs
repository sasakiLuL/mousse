using Domain.Results;
using MediatR;

namespace Application.Messaging;

public interface ICommandBase 
{ }

public interface ICommand : IRequest<Result>, ICommandBase 
{ }

public interface ICommand<TResponce> : IRequest<Result<TResponce>>, ICommandBase 
{ }

