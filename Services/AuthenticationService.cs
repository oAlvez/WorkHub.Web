using WorkHub.Web.Models.Authentication;
using WorkHub.Web.Services.Interfaces;
using WorkHub.Web.Services.Interfaces.Base;

namespace WorkHub.Web.Services;
public class AuthenticationService(IHttpService _httpService) : IAuthenticationService
{
    public async Task<AuthenticationResponse?> LoginAsync(AuthenticationRequest request) => 
        await _httpService.PostAsync<AuthenticationResponse>("Authentication", request);
}