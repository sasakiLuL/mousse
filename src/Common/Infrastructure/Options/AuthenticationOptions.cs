namespace Infrastructure.Options;

public class AuthenticationOptions
{
    public string Address { get; internal set; } = string.Empty;

    public string Realm { get; internal set; } = string.Empty;

    public string ClientId { get; internal set; } = string.Empty;

    public string Audience { get; internal set; } = string.Empty;

    public string Secret { get; internal set; } = string.Empty;

    public bool? RequireHttpsMetadata { get; internal set; } = true;

    public bool? ValidateIssuer { get; internal set; } = true;

    public static readonly string Section = "Authentication";
}
