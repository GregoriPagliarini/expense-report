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
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<UserModelValueObject> Post(UserModelValueObject userModelVO)
        {
            return await _userService.Create(userModelVO);
        }
        
        [HttpPut]
        public async Task<UserModelValueObject> Put(UserModelValueObject userModelVO)
        {
            return await _userService.Update(userModelVO);
        }
        
        [HttpGet]
        public async Task<UserModelValueObject> Get(int id)
        {
            return await _userService.FindById(id);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _userService.Delete(id);
        }


    }
}