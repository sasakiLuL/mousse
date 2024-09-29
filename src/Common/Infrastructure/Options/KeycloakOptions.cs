namespace Authorization.Options;

public class AuthenticationOptions
{
    public string Address { get; set; } = "";

    public string Realm { get; set; } = "";

    public string ClientId { get; set; } = "";

    public string Audience { get; set; } = "";

    public string Secret { get; set; } = "";

    public bool? RequireHttpsMetadata { get; set; }

    public bool? ValidateIssuer { get; set; }

    public static readonly string Section = "Authentication";
}
