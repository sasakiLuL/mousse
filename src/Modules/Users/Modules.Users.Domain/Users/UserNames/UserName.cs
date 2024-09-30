using Domain.Entities;
using Domain.Results;
using FluentValidation;

namespace mousse.Domain.Users.UserNames;

public record UserName : ValueObject
{
    public const int MaximumLength = 100;

    public const string FormatString = @"^[a-zA-Z -!|]*";

    private UserName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<UserName> Create(string value)
    {
        return Validate(
            new UserNameValidator(),
            new UserName(value));
    }
}

public class UserNameValidator : AbstractValidator<UserName>
{
    public UserNameValidator() : base()
    {
        RuleFor(p => p.Value)
            .MaximumLength(UserName.MaximumLength)
                .WithError(UserNameErrors.TooLong)
            .Matches(UserName.FormatString)
                .WithError(UserNameErrors.InvalidFormat);
    }
}
