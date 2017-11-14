using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/values
        [HttpGet]
        public List<Object> Get()
        {
            return _userService.UserList();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<FacebookResponse> Login([FromBody]FacebookLoginData facebookLoginData)
        {
            return await _userService.Login(facebookLoginData.UserId, facebookLoginData.AccessToken);
        }
    }
}
