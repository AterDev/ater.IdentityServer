using Definition.Share.Models.ApplicationDtos;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Application.Manager;
public class ApplicationManager(IOpenIddictApplicationManager manager)
{
    private readonly IOpenIddictApplicationManager manager = manager;

    /// <summary>
    /// 添加更新应用
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task CreateOrUpdateAsync(ApplicationAddDto dto)
    {
        var application = await manager.FindByClientIdAsync(dto.ClientId);
        var descriptor = new OpenIddict.Abstractions.Application
        {
            ClientId = dto.ClientId,
            ClientSecret = dto.ClientSecret,
            DisplayName = dto.DisplayName,

            ClientType = dto.IsConfidential ? ClientTypes.Confidential : ClientTypes.Public,
            ConsentType = dto.ConsentType switch
            {
                ConsentType.Explicit => ConsentTypes.Explicit,
                ConsentType.Implicit => ConsentTypes.Implicit,
                _ => ConsentTypes.Systematic
            }
        };
        if (descriptor.ClientType == ClientTypes.Public)
        {
            descriptor.ClientSecret = null;
        }

        if (dto.RedirectUris.Count > 0)
        {
            descriptor.RedirectUris.Clear();
            dto.RedirectUris.ForEach(r =>
            {
                descriptor.RedirectUris.Add(new Uri(r));
            });
        }

        if (dto.PostLogoutRedirectUris.Count > 0)
        {
            descriptor.PostLogoutRedirectUris.Clear();
            dto.PostLogoutRedirectUris.ForEach(r =>
            {
                descriptor.PostLogoutRedirectUris.Add(new Uri(r));
            });
        }

        if (dto.Permissions.Count > 0)
        {
            descriptor.Permissions.Clear();
            dto.Permissions.ForEach(p =>
            {
                descriptor.Permissions.Add(p);
            });
        }
        if (dto.Roles.Count > 0)
        {

            descriptor.Requirements.Clear();
            dto.Roles.ForEach(r =>
            {
                descriptor.Requirements.Add(r);
            });

            await manager.CreateAsync(descriptor);
        }

        if (dto.Scopes.Count > 0)
        {
            descriptor.Permissions.RemoveWhere(p => p.StartsWith(Permissions.Prefixes.Scope));
            dto.Scopes.ForEach(s =>
            {
                descriptor.Permissions.Add(Permissions.Prefixes.Scope + s);
            });
        }

        if (dto.AllowLogoutEndpoint)
        {
            descriptor.Permissions.Add(Permissions.Endpoints.Logout);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.Endpoints.Logout);
        }

        if (dto.AllowAuthorizationCodeFlow || dto.AllowHybridFlow)
        {
            descriptor.Permissions.Add(Permissions.GrantTypes.AuthorizationCode);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.GrantTypes.AuthorizationCode);
        }

        if (dto.AllowClientCredentialsFlow)
        {
            descriptor.Permissions.Add(Permissions.GrantTypes.ClientCredentials);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.GrantTypes.ClientCredentials);
        }

        if (dto.AllowHybridFlow || dto.AllowImplicitFlow)
        {
            descriptor.Permissions.Add(Permissions.GrantTypes.Implicit);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.GrantTypes.Implicit);
        }

        if (dto.AllowPasswordFlow)
        {
            descriptor.Permissions.Add(Permissions.GrantTypes.Password);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.GrantTypes.Password);
        }

        if (dto.AllowRefreshTokenFlow)
        {
            descriptor.Permissions.Add(Permissions.GrantTypes.RefreshToken);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.GrantTypes.RefreshToken);
        }

        if (dto.AllowAuthorizationCodeFlow || dto.AllowHybridFlow || dto.AllowImplicitFlow)
        {
            descriptor.Permissions.Add(Permissions.Endpoints.Authorization);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.Endpoints.Authorization);
        }

        if (dto.AllowAuthorizationCodeFlow || dto.AllowHybridFlow ||
            dto.AllowClientCredentialsFlow || dto.AllowPasswordFlow || dto.AllowRefreshTokenFlow)
        {
            descriptor.Permissions.Add(Permissions.Endpoints.Token);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.Endpoints.Token);
        }

        if (dto.AllowAuthorizationCodeFlow)
        {
            descriptor.Permissions.Add(Permissions.ResponseTypes.Code);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.ResponseTypes.Code);
        }

        if (dto.AllowImplicitFlow)
        {
            descriptor.Permissions.Add(Permissions.ResponseTypes.IdToken);

            if (string.Equals(descriptor.ClientType, ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
            {
                descriptor.Permissions.Add(Permissions.ResponseTypes.IdTokenToken);
                descriptor.Permissions.Add(Permissions.ResponseTypes.Token);
            }
            else
            {
                descriptor.Permissions.Remove(Permissions.ResponseTypes.IdTokenToken);
                descriptor.Permissions.Remove(Permissions.ResponseTypes.Token);
            }
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.ResponseTypes.IdToken);
            descriptor.Permissions.Remove(Permissions.ResponseTypes.IdTokenToken);
            descriptor.Permissions.Remove(Permissions.ResponseTypes.Token);
        }

        if (dto.AllowHybridFlow)
        {
            descriptor.Permissions.Add(Permissions.ResponseTypes.CodeIdToken);

            if (string.Equals(descriptor.ClientType, ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
            {
                descriptor.Permissions.Add(Permissions.ResponseTypes.CodeIdTokenToken);
                descriptor.Permissions.Add(Permissions.ResponseTypes.CodeToken);
            }
            else
            {
                descriptor.Permissions.Remove(Permissions.ResponseTypes.CodeIdTokenToken);
                descriptor.Permissions.Remove(Permissions.ResponseTypes.CodeToken);
            }
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.ResponseTypes.CodeIdToken);
            descriptor.Permissions.Remove(Permissions.ResponseTypes.CodeIdTokenToken);
            descriptor.Permissions.Remove(Permissions.ResponseTypes.CodeToken);
        }

        if (dto.AllowIntrospectionEndpoint)
        {
            descriptor.Permissions.Add(Permissions.Endpoints.Introspection);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.Endpoints.Introspection);
        }

        if (dto.AllowRevocationEndpoint)
        {
            descriptor.Permissions.Add(Permissions.Endpoints.Revocation);
        }
        else
        {
            descriptor.Permissions.Remove(Permissions.Endpoints.Revocation);
        }

        if (dto.RequireProofKeyForCodeExchange)
        {
            descriptor.Requirements.Add(Requirements.Features.ProofKeyForCodeExchange);
        }
        else
        {
            descriptor.Requirements.Remove(Requirements.Features.ProofKeyForCodeExchange);
        }

        if (application is null)
        {

            await manager.CreateAsync(descriptor);
        }
        else
        {
            await manager.UpdateAsync(application, descriptor);
        }
    }
}
