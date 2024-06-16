using FluentValidation;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Core.Entities;

public record ValueObject
{
    protected static Result<TValue> Validate<TValue>(
        AbstractValidator<TValue> validator,
        TValue instance)
    {
        return validator
            .Validate(instance)
            .ToResult(instance);
    }
}
