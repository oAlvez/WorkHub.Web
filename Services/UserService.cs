using WorkHub.Web.Models.User;
using WorkHub.Web.Services.Interfaces;
using WorkHub.Web.Services.Interfaces.Base;

namespace WorkHub.Web.Services;
public class UserService(IHttpService _httpService) : IUserService
{
    public async Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest model) => 
        await _httpService.PostAsync<CreateUserResponse>("User", model);
}