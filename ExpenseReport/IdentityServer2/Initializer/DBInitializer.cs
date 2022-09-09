using IdentityModel;
using IdentityServer2.Config;
using IdentityServer2.Model;
using IdentityServer2.Model.Context;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer2.Initializer
{
    public class DBInitializer : IDBInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DBInitializer(MySQLContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new()
            {
                UserName = "srv.admin",
                Email = "gregori.longhi@hotmail.com",
                EmailConfirmed = true,
                PhoneNumber = "5554999999999",
                FirstName = "admin",
                LastName = "admin"
            };

            _user.CreateAsync(admin, "S3nh4$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, admin.FirstName),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            }).Result;

            ApplicationUser client = new()
            {
                UserName = "client",
                Email = "gregori.longhi@hotmail.com",
                EmailConfirmed = true,
                PhoneNumber = "5554999999999",
                FirstName = "client",
                LastName = "client"
            };

            _user.CreateAsync(client, "S3nh4$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, client.FirstName),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
            }).Result;

        }
    }
}
