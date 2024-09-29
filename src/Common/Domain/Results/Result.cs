using Domain.Errors;

namespace Domain.Results;

public class Result
{
    protected Result(bool isSuccess, Error[] errors)
    {
        if (isSuccess && errors.Any())
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && !errors.Any())
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

    public static Result AllFailuresOrSuccess(params Result[] results)
    {
        var errors = results.SelectMany(x => x.Errors);

        if (errors.Any())
        {
            return Failure([.. errors]);
        }

        return Success();
    }
}
