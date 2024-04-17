using Definition.EntityFramework.DBProvider;
using Definition.Share.Models.SystemUserDtos;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Http.API.Worker;

public class InitDataWorker
{
    public static async Task InitAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<CommandDbContext>();
        await context.Database.MigrateAsync();

        var applicationManager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
        await InitOpenIdApplicationAsync(applicationManager);
        var systemUserManager = scope.ServiceProvider.GetRequiredService<SystemUserManager>();

        await InitSystemUserAsync(systemUserManager);
    }

    private static async Task InitOpenIdApplicationAsync(IOpenIddictApplicationManager manager)
    {
        if (await manager.FindByClientIdAsync("service-worker") is null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "service-worker",
                ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.ClientCredentials
                }
            });
        }
    }

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
