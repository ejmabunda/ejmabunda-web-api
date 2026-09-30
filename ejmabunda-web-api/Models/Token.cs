public record Token
{
    public required string AccessToken { get; set; }
    public required int ExpiresIn { get; set; }
}