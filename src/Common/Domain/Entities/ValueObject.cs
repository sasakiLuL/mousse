using Domain.Results;
using FluentValidation;

namespace Domain.Entities;

public record ValueObject()
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
