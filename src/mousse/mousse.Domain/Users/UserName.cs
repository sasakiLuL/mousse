using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Errors;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Users;

public record UserName : ValueObject
{
    public const int MaxLenght = 100;

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
            .MaximumLength(UserName.MaxLenght)
                .WithError(DomainErrors.UserName.TooLong)
            .Matches(UserName.FormatString)
                .WithError(DomainErrors.UserName.InvalidFormat);
    }
}
