using mousse.Domain.Core.Errors;

namespace mousse.Domain.Core.Results;

public static class ResultExtensions
{
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<Error[], T> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result.Errors);
    }
}
