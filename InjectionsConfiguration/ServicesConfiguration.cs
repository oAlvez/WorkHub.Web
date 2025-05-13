using WorkHub.Web.Services;
using WorkHub.Web.Services.Base;
using WorkHub.Web.Services.Interfaces;
using WorkHub.Web.Services.Interfaces.Base;

namespace WorkHub.Web.Controllers.InjectionsConfiguration;
public static class ServicesConfiguration
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddHttpClient<IHttpService, HttpService>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}