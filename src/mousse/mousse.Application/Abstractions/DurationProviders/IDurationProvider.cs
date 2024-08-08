namespace mousse.Application.Abstractions.DurationProviders;

public interface IDurationProvider
{
    Task<int> GetAudioDurrationInSecondsAsync(Stream file, CancellationToken token = default);
}
