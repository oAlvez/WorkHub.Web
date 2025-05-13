using WorkHub.Web.Models.Authentication;

namespace WorkHub.Web.Services.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponse?> LoginAsync(AuthenticationRequest request);
}
