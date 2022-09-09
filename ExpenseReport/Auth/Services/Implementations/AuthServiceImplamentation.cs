using Auth.Data.ValueObjects;
using Auth.Model;
using Auth.Repository.Interface;
using Auth.Services;
using IdentityModel.Client;
using System.Security.Policy;
using System.Text.Json.Nodes;
using System.Text;
using Newtonsoft.Json;

namespace Auth.Services.Implementations
{
    public class AuthServiceImplamentation : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        HttpClient client = new();


        public AuthServiceImplamentation(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthValueObject> Login(AuthValueObject authValueObject)
        {
            if (!await CheckCredentials(authValueObject))
                throw new Exception("Password not valid");

            authValueObject.Token = await GetToken();
            
            return authValueObject;
        }

        private async Task<string> GetToken()
        {
            var result = await client.GetAsync("https://localhost:4440/api/CredentialValidation");

            return await result.Content.ReadAsStringAsync();
        }

        private async Task<bool> CheckCredentials(AuthValueObject authValueObject)
        {
            var result = await client.PostAsync("https://localhost:4440/api/CredentialValidation",
                new StringContent(JsonConvert.SerializeObject(authValueObject), Encoding.UTF8, "application/json"));

            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(response);
        }
    }
}
