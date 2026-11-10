/// <summary>
/// Access-token payload returned by the login and refresh endpoints, wrapped as
/// <c>{ "token": { "accessToken": "…", "expiresIn": 600 } }</c>.
/// </summary>
public record Token
{
    /// <summary>The signed JWT.</summary>
    public required string AccessToken { get; set; }

    /// <summary>Seconds until the access token expires.</summary>
    public required int ExpiresIn { get; set; }
}