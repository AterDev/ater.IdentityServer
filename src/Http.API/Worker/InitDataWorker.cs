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

        var systemUserManager = scope.ServiceProvider.GetRequiredService<SystemUserManager>();

        await InitSystemUserAsync(systemUserManager);
    }

    //private static async Task InitOpenIdApplicationAsync(IOpenIddictApplicationManager manager)
    //{

    //}

    private static async Task InitSystemUserAsync(SystemUserManager manager)
    {
        var exist = await manager.FindAsync<SystemUser>(u => u.UserName == "admin");
        if (exist != null)
        {
            var user = new SystemUserAddDto
            {
                UserName = "admin",
                Email = "admin@ater.com",
                Password = "docs.dusi.dev"

            };
            await manager.CreateNewEntityAsync(user);
        }
    }
}
