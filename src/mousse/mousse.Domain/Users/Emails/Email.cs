using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Users.Emails;

public record Email : ValueObject
{
    public const int MaximumLength = 256;

    public const string FormatString = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Email> Create(string value)
    {
        return Validate(
            new EmailValidator(),
            new Email(value));
    }
}

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator() : base()
    {
        RuleFor(p => p.Value)
            .MaximumLength(Email.MaximumLength)
                .WithError(EmailErrors.TooLong)
            .Matches(Email.FormatString)
                .WithError(EmailErrors.InvalidFormat);
    }
}
