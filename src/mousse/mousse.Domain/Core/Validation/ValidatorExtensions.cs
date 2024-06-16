using FluentValidation;
using FluentValidation.Results;
using mousse.Domain.Core.Errors;
using mousse.Domain.Core.Results;

namespace mousse.Domain.Core.Validation;

public static class ValidatorExtensions
{
    public static Error ToError(this ValidationFailure failure)
    {
        return new Error(failure.ErrorCode, failure.ErrorMessage);
    }

    public static Result ToResult(this ValidationResult result)
    {
        return result.IsValid ?
            Result.Success() :
            Result.Failure(result.Errors.Select(e => e.ToError()).ToArray());
    }

    public static Result<TValue> ToResult<TValue>(this ValidationResult result, TValue value)
    {
        return result.IsValid ?
            Result.Success(value) :
            Result.Failure<TValue>(result.Errors.Select(e => e.ToError()).ToArray());
    }

    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilder,
        Error failure)
    {
        return ruleBuilder.WithErrorCode(failure.Code).WithMessage(failure.Message);
    }
}
