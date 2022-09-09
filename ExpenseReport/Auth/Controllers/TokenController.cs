using Auth.Repository.Interface;
using Auth.Services;
using Auth.Utils;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<TokenController> _logger;

        public TokenController(ITokenService tokenService, ILogger<TokenController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<TokenResponse> Get()
        {
            return await _tokenService.GetToken("expensereport");
        }
    }
}