using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Errors;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Playlists;

public record PlaylistName : ValueObject
{
    public const int MaxLenght = 100;

    public const string FormatString = @"^[\p{L}0-9 ,\.\/\\!@#$%&*+()_-]*";

    private PlaylistName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PlaylistName> Create(string value)
    {
        return Validate(
            new PlaylistNameValidator(),
            new PlaylistName(value));
    }
}

internal class PlaylistNameValidator : AbstractValidator<PlaylistName>
{
    public PlaylistNameValidator() : base()
    {
        RuleFor(p => p.Value)
            .MaximumLength(PlaylistName.MaxLenght)
                .WithError(DomainErrors.PlaylistName.TooLong)
            .Matches(PlaylistName.FormatString)
                .WithError(DomainErrors.PlaylistName.InvalidFormat);
    }
}
