using EBuy.Core.Models;
using EBuy.Core.Services;
using EBuy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.API.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
