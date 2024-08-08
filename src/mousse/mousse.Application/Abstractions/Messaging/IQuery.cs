using MediatR;
using mousse.Domain.Core.Results;

namespace mousse.Application.Abstractions.Messaging;

public interface IQuery<TResponce>
    : IRequest<Result<TResponce>> {}
