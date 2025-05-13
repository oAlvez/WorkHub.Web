using WorkHub.Web.Models.Configurations;

namespace WorkHub.Web.Controllers.InjectionsConfiguration;
public static class OptionsConfiguration
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiConfiguration>(opt => configuration.GetSection("Api").Bind(opt));
        return services;
    }
}