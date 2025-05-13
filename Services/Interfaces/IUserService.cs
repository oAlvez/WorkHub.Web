using WorkHub.Web.Models.User;

namespace WorkHub.Web.Services.Interfaces;
public interface IUserService
{
    Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest model);
}