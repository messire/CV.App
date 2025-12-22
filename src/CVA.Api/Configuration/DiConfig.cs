namespace CVA.Api;

public static class DiConfig
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddControllers();
        
        services.AddScoped<IUserService, UserService>();

    }
}