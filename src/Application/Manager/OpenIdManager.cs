using OpenIddict.Abstractions;

namespace Application.Manager;

/// <summary>
/// 
/// </summary>
public class OpenIdManager(IOpenIddictApplicationManager applicationManager,
    IOpenIddictAuthorizationManager authorizationManager,
    IOpenIddictScopeManager scopeManager,
    IOpenIddictTokenManager tokenManager)
{
    private readonly IOpenIddictApplicationManager applicationManager = applicationManager;
    private readonly IOpenIddictAuthorizationManager authorizationManager = authorizationManager;
    private readonly IOpenIddictScopeManager scopeManager = scopeManager;
    private readonly IOpenIddictTokenManager tokenManager = tokenManager;

}
