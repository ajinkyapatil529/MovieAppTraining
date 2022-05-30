using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Business.Services;
using MovieApp.Entity;
namespace MovieApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserServices _userService;
        public UserController(UserServices userServices)
        {
            _userService = userServices;
        }

        [HttpGet("SelectUsers")]
        public IActionResult SelectUser()
        {
            return Ok(_userService.SelectUser());
        }
        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }

    }
}
