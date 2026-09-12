/// <summary>
/// Strongly-typed binding of the <c>ApiSettings</c> configuration section (see the
/// Configuration table in the README). Bound in <c>Program.cs</c>.
/// </summary>
public class ApiSettings
{
    /// <summary>The API's public base URL; also the JWT issuer and audience.</summary>
    public string ApiUrl { get; set; } = string.Empty;

    /// <summary>The single browser origin allowed through CORS.</summary>
    public string FrontendUrl { get; set; } = string.Empty;

    /// <summary>Base64 HMAC-SHA256 key used to hash refresh tokens before storage. Secret; not committed.</summary>
    public string RefreshTokenHashKey { get; set; } = string.Empty;

    /// <summary>Access-token lifetime, in minutes.</summary>
    public int AccessTokenLifetimeInMinutes { get; set; }
}