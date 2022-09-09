using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Policy;
using System.Threading.Tasks;
using Auth.Config;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auth.Services.Implementations
{
    public class TokenServiceImplementation : ITokenService
    {
        private readonly ILogger<TokenServiceImplementation> _logger;
        private readonly IOptions<IdentityServerSettings> _identityServerSettings;
        private readonly DiscoveryDocumentResponse _discoveryDocument;

        public TokenServiceImplementation(ILogger<TokenServiceImplementation> logger, IOptions<IdentityServerSettings> identityServerSettings)
        {
            _logger = logger;
            _identityServerSettings = identityServerSettings;

            using var httpClient = new HttpClient();
            _discoveryDocument = httpClient.GetDiscoveryDocumentAsync(identityServerSettings.Value.DiscoveryUrl).Result;
            if (_discoveryDocument.IsError)
            {
                logger.LogError($"Unable to get discovery document. Error is: {_discoveryDocument.Error}");
                throw new Exception("Unable to get discovery document", _discoveryDocument.Exception);
            }
        }

        public async Task<TokenResponse> GetToken(string scope)
        {
            using var client = new HttpClient();

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _discoveryDocument.TokenEndpoint,
                ClientId = _identityServerSettings.Value.ClientName,
                ClientSecret = _identityServerSettings.Value.ClientPassword,
                Scope = scope,
                GrantType = "client_credentials"
            });


            if (tokenResponse.IsError)
            {
                _logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }

    }
}
