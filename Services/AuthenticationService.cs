using WorkHub.Web.Models.Authentication;
using WorkHub.Web.Services.Interfaces;

namespace WorkHub.Web.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("https://workhubflow.com.br:2053/api/Authentication", request);

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException("Login inválido.");

        return (await response.Content.ReadFromJsonAsync<LoginResponse>())!;
    }
}