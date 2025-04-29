using Microsoft.Extensions.Caching.Memory;
using WorkHub.Web.Services.Interfaces.Extensions;

namespace WorkHub.Web.Services.Extensions;

public class TokenCacheService(IMemoryCache _memoryCache) : ITokenCacheService
{
    public string? GetTokenAsync()
    {
        _memoryCache.TryGetValue("AccessToken", out string? token);
        return token;
    }

    public void SetTokenAsync(string token, DateTimeOffset expiration)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = expiration
        };

        _memoryCache.Set("AccessToken", token, cacheEntryOptions);
    }
}
