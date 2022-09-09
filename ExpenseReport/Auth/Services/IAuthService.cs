using Auth.Data.ValueObjects;
using Auth.Model;
using IdentityModel.Client;

namespace Auth.Services
{
    public interface IAuthService
    {
        Task<AuthValueObject> Login(AuthValueObject authValueObject);
    }
}
