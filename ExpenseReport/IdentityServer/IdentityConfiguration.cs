using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
static class ConfigurationManager
{
    public static IConfiguration AppSetting { get; }
    static ConfigurationManager()
    {
        AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    }
}

public static class IdentityConfiguration
{
    public static IEnumerable<IdentityResource> IdentityResources =>
      new[]
      {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource
        {
          Name = "role",
          UserClaims = new List<string> {"role"}
        }
      };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("expensereport", "ExpenseReport Server"),
            new ApiScope("read", "Read data."),
            new ApiScope("write", "Write data."),
            new ApiScope("delete", "Delete data.")
        };
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "m2m.client",
                ClientSecrets = { new Secret(ConfigurationManager.AppSetting["m2mSecret"].Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "expensereport", "read", "write", "profile" }
            },
            new Client
            {
                ClientId = "c2m.client",
                ClientSecrets = { new Secret(ConfigurationManager.AppSetting["c2mSecret"].Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "" },
                PostLogoutRedirectUris = { "" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "expensereport"
                }
            }
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("expensereport")
            {
                Scopes = new List<string> { "expensereport", "read", "write", "profile" },
                ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };

}
