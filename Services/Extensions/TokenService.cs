using WorkHub.Web.Models.Authentication;
using WorkHub.Web.Services.Interfaces.Base;
using WorkHub.Web.Services.Interfaces.Extensions;

namespace WorkHub.Web.Services.Extensions;

public class TokenService(IHttpService _httpService, ITokenCacheService _tokenCache) : ITokenService
{
    public async Task<string> GetAccessTokenAsync()
    {
        var token = _tokenCache.GetTokenAsync();

        if (token == null)
        {
            var authentication = await _httpService.PostAsync<LoginResponse>("Authentication/GetToken",
                new LoginRequest { Username = "guilherme@workhubflow.com.br", Password = "Admin!@#123"});

            if (authentication?.accessToken is not null)
            {
                token = authentication.accessToken;
                var expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(authentication.expiration));

                _tokenCache.SetTokenAsync(token, expirationTime);
            }
        }

        if (token == null)
            throw new Exception("Não foi possível obter o token de autenticação da API.");

        return token;
    }
}
