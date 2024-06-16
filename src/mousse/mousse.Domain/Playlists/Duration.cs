using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Errors;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Playlists;

public record Duration : ValueObject
{
    public int Seconds { get; }

    public int Minutes { get => Seconds / 60; }

    public int Hours { get => Seconds / 3600; }

    private Duration(int seconds)
    {
        Seconds = seconds;
    }

    public static Result<Duration> Create(int seconds)
    {
        return Validate(
            new DurationValidator(),
            new Duration(seconds));
    }
}

internal class DurationValidator : AbstractValidator<Duration>
{
    public DurationValidator()
    {
        RuleFor(d => d.Seconds)
            .LessThanOrEqualTo(0)
                .WithError(DomainErrors.Duration.LessThanZero);
    }
}
