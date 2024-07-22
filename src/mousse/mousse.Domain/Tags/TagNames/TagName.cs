using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Errors;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Tags.TagNames;

public record TagName : ValueObject
{
    public const int MaxLenght = 100;

    public const string FormatString = @"^[a-zA-Z -]*";

    private TagName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    internal static Result<TagName> Create(string value)
    {
        return Validate(
            new TagNameValidator(),
            new TagName(value));
    }
}

internal class TagNameValidator : AbstractValidator<TagName>
{
    public TagNameValidator() : base()
    {
        RuleFor(p => p.Value)
            .MaximumLength(TagName.MaxLenght)
                .WithError(TagNameErrors.TooLong)
            .Matches(TagName.FormatString)
                .WithError(TagNameErrors.InvalidFormat);
    }
}