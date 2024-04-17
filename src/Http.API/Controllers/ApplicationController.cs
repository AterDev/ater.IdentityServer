
using OpenIddict.Abstractions;

namespace Http.API.Controllers;

public class ApplicationController(
    OpenIdManager manager,
    IOpenIddictApplicationManager applicationManager,
    IUserContext user,
    ILogger logger) : RestControllerBase<OpenIdManager>(manager, user, logger)
{
    private readonly IOpenIddictApplicationManager applicationManager = applicationManager;

    [HttpGet]
    public void GetApplicationList(FilterBase filter)
    {

    }

    /// <summary>
    /// 添加应用
    /// </summary>
    /// <param name="descriptor"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task AddApplicationAsync(OpenIddictApplicationDescriptor descriptor)
    {
        await applicationManager.CreateAsync(descriptor);
    }

    [HttpPut]
    public async Task UpdateApplicationAsync(OpenIddictApplicationDescriptor descriptor)
    {
        await applicationManager.UpdateAsync(descriptor);
    }

    [HttpGet("{id}")]
    public async Task UpdateApplicationAsync(Guid id)
    {
        await applicationManager.FindByIdAsync(id.ToString());
    }

    [HttpDelete("{id}")]
    public async Task DeleteApplicationAsync(Guid id)
    {
        await applicationManager.DeleteAsync(id);
    }

}
