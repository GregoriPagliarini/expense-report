using User.Services;
using User.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Data.ValueObjects;
using User.Model;

namespace User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CredentialValidationController : ControllerBase
    {
        IUserService _userService;

        public CredentialValidationController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<bool> Post(AuthValueObject authVO)
        {
            return await _userService.ValidateCredentials(authVO);
        }
    }
}