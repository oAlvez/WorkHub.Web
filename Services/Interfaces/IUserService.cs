using WorkHub.Web.Models.User;

namespace WorkHub.Web.Services.Interfaces;

public interface IUserService
{
    Task<bool> CreateUserAsync(CreateUserRequest model);
}
