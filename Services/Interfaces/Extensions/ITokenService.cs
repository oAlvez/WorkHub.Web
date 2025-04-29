namespace WorkHub.Web.Services.Interfaces.Extensions;

public interface ITokenService
{
    Task<string> GetAccessTokenAsync();
}
