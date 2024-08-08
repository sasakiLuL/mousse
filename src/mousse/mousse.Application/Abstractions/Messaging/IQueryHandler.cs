using MediatR;
using mousse.Domain.Core.Results;

namespace mousse.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse> {}
