using Microsoft.AspNetCore.Identity;

namespace IdentityServer2.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
