namespace WorkHub.Web.Controllers.InjectionsConfiguration;
public static class SessionConfiguration
{
    public static IServiceCollection AddSessionConfiguration(this IServiceCollection services)
    {
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddDistributedMemoryCache();
        return services;
    }
}