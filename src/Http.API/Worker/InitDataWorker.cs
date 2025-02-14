using Definition.EntityFramework.DBProvider;
using Definition.Share.Models.SystemUserDtos;

namespace Http.API.Worker;

public class InitDataWorker
{
    public static async Task InitAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CommandDbContext>();
        await context.Database.MigrateAsync();

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<InitDataWorker>>();

        var systemUserManager = scope.ServiceProvider.GetRequiredService<SystemUserManager>();

        await InitSystemUserAsync(systemUserManager, logger);
        await InitConfigsAsync(context, logger);
    }

    private static async Task InitConfigsAsync(CommandDbContext context, ILogger<InitDataWorker> logger)
    {
        if (!context.Configs.Any(c => c.Group.Equals(Constants.Config.DefaultGroup)))
        {
            var configs = Config.DefaultPermissionConfigs();
            context.AddRange(configs);
            await context.SaveChangesAsync();
            logger.LogInformation("Init configs");
        }
    }

    private static async Task InitSystemUserAsync(SystemUserManager manager, ILogger<InitDataWorker> logger)
    {
        var exist = await manager.FindAsync<SystemUser>(u => u.UserName == "admin");
        if (exist == null)
        {
            var user = new SystemUserAddDto
            {
                UserName = "admin",
                Email = "admin@ater.com",
                Password = "docs.dusi.dev"
            };
            await manager.AddAsync(user);
            logger.LogInformation("Init systemUse:{UserName}/{Password}", user.UserName, user.Password);
        }
    }
}
