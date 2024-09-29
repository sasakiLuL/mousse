using Domain.Results;
using MediatR;

namespace Application.Messaging;

public interface IQuery<TResponce> : IRequest<Result<TResponce>>
{ }
