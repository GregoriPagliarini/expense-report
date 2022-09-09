using Auth.Data.ValueObjects;
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
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService, IAuthRepository authRepository)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<AuthValueObject> Post(AuthValueObject authValueObject)
        {
            return await _authService.Login(authValueObject);
        }
    }
}