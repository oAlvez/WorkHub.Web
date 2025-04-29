using WorkHub.Web.Models.User;
using WorkHub.Web.Services.Interfaces;

namespace WorkHub.Web.Services;

public class UserService(HttpClient _httpClient) : IUserService
{
    public async Task<bool> CreateUserAsync(CreateUserRequest model)
    {
        var response = await _httpClient.PostAsJsonAsync("https://workhubflow.com.br:2053/api/User", model);

        return response.IsSuccessStatusCode;
    }
}