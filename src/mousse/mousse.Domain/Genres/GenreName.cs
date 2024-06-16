using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Errors;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Genres;

public record GenreName : ValueObject
{
    public const int MaxLenght = 100;

    public const string FormatString = @"^[a-zA-Z -]*";

    private GenreName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<GenreName> Create(string value)
    {
        return Validate(
            new GenreNameValidator(),
            new GenreName(value));
    }
}

internal class GenreNameValidator : AbstractValidator<GenreName>
{
    public GenreNameValidator() : base()
    {
        RuleFor(p => p.Value)
            .MaximumLength(GenreName.MaxLenght)
                .WithError(DomainErrors.GenreName.TooLong)
            .Matches(GenreName.FormatString)
                .WithError(DomainErrors.GenreName.InvalidFormat);
    }
}