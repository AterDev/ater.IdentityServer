// 本文件由 ater.dry工具自动生成.
namespace Application;

public static partial class ManagerServiceCollectionExtensions
{
    public static void AddManager(this IServiceCollection services)
    {
        services.AddScoped(typeof(DataAccessContext<>));
        services.AddScoped(typeof(ApplicationManager));
        services.AddScoped(typeof(ConfigManager));
        services.AddScoped(typeof(ScopeManager));
        services.AddScoped(typeof(SystemUserManager));

    }
}
