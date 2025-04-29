namespace WorkHub.Web.Controllers.InjectionsConfiguration;
public static class OptionsConfiguration
{
    public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<AzureADConfiguration>(opt => configuration.GetSection("AzureAD").Bind(opt));
        return services;
    }
}