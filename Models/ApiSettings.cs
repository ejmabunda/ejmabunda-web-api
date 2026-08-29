public class ApiSettings
{
    public string ApiUrl { get; set; } = string.Empty;
    public string FrontendUrl { get; set; } = string.Empty;
    public string RefreshTokenHashKey { get; set; } = string.Empty;
    public int AccessTokenLifetimeInMinutes { get; set; }
}