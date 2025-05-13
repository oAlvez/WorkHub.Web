using System.ComponentModel;

namespace WorkHub.Web.Models.Authentication;
public class AuthenticationRequest
{
    [Description("Email")]
    public string Username { get; set; } = string.Empty;
    [Description("Senha")]
    public string Password { get; set; } = string.Empty;
}