using OpenIddict.Abstractions;

namespace Definition.Share.Models.ApplicationDtos;
public class ApplicationItemDto
{
    public object? ApplicationType { get; set; }
    public List<OpenIddictAuthorizationDescriptor> Authorizations { get; set; } = [];
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ClientType { get; set; }
    public Guid ConcurrencyToken { get; set; }
    public object? ConsentType { get; set; }
    public object? DisplayName { get; set; }
    public object? DisplayNames { get; set; }
    public Guid Id { get; set; }
    public object? JsonWebKeySet { get; set; }
    public string? Permissions { get; set; }
    public object? PostLogoutRedirectUris { get; set; }
    public object? Properties { get; set; }
    public object? RedirectUris { get; set; }
    public object? Requirements { get; set; }
    public object? Settings { get; set; }
    public List<OpenIddictTokenDescriptor> Tokens { get; set; } = [];
}
