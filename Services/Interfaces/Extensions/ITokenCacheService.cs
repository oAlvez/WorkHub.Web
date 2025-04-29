namespace WorkHub.Web.Services.Interfaces.Extensions;

public interface ITokenCacheService
{
    string? GetTokenAsync();
    void SetTokenAsync(string token, DateTimeOffset expiration);
}
