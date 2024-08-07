﻿using FluentValidation;
using mousse.Domain.Core.Entities;
using mousse.Domain.Core.Results;
using mousse.Domain.Core.Validation;

namespace mousse.Domain.Playlists.Tracks.TrackNames;

public record TrackName : ValueObject
{
    public const int MaxLenght = 100;

    public const string FormatString = @"^[\p{L}0-9 ,\.\/\\!@#$%&*+()_-]*";

    private TrackName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<TrackName> Create(string value)
    {
        return Validate(
            new TrackNameValidator(),
            new TrackName(value));
    }
}

internal class TrackNameValidator : AbstractValidator<TrackName>
{
    public TrackNameValidator() : base()
    {
        RuleFor(p => p.Value)
            .MaximumLength(TrackName.MaxLenght)
                .WithError(TrackNameErrors.TooLong)
            .Matches(TrackName.FormatString)
                .WithError(TrackNameErrors.InvalidFormat);
    }
}