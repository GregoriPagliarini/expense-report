using Duende.IdentityServer2;
using Duende.IdentityServer2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IdentityServer2.Config
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("ExpenseReport", "ExpenseReport Server"),
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
                    ClientSecrets = { new Secret(new ConfigurationManager().GetSection("m2mSecret").ToString().Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "Read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "c2m.client",
                    ClientSecrets = { new Secret(new ConfigurationManager().GetSection("c2mSecret").ToString().Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "" },
                    PostLogoutRedirectUris = { "" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "ExpenseReport"
                    }
                }
            };
    }
}
