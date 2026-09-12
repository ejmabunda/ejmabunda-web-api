/// <summary>Request body for <c>POST /api/Auth/login</c>.</summary>
public record LoginRequest
{
    /// <summary>The admin password, sent over TLS and verified against the stored hash.</summary>
    public required string Password { get; set; }
}