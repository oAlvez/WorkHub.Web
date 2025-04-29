namespace WorkHub.Web.Models.Authentication;

public class LoginResponse
{
    public bool authenticated { get; set; }
    public string created { get; set; } = string.Empty;
    public string expiration { get; set; } = string.Empty;
    public string accessToken { get; set; } = string.Empty;
}
