using mousse.Domain.Core.Errors;

namespace mousse.Domain.Core.Results;

public class Result
{
    protected Result(bool isSuccess, Error[] errors)
    {
        if (isSuccess && !errors.Any())
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && errors.Any())
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error[] Errors { get; }

    public static Result Success() => new Result(true, []);

    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, []);

    public static Result Failure(Error[] errors) => new Result(false, errors);

    public static Result Failure(Error error) => new Result(false, [error]);

    public static Result<TValue> Failure<TValue>(Error[] errors) => new Result<TValue>(default!, false, errors);

    public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, [error]);

    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.IsFailure)
            {
                return result;
            }
        }

        return Success();
    }

    public static IEnumerable<Error> GetAllErrors(params Result[] results)
    {
        return results.SelectMany(x => x.Errors);
    }
}
