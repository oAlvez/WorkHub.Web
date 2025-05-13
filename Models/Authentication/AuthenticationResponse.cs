namespace WorkHub.Web.Models.Authentication;

public class AuthenticationResponse
{
    public bool Authenticated { get; set; }
    public string Created { get; set; } = string.Empty;
    public string Expiration { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string? Message { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}