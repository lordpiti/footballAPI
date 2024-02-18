using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels.User;
using Football.Crosscutting.Enums;

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
        public async Task<List<UserData>> Get()
        {
            return await _userService.UserList();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<LoginResponse> Login([FromBody]LoginData facebookLoginData)
        {
            return await _userService.Login(LoginTypeEnum.Facebook, facebookLoginData.UserId, facebookLoginData.AccessToken);
        }

        [HttpPost]
        [Route("LoginGoogle")]
        public async Task<LoginResponse> LoginGoogle([FromBody]LoginData googleLoginData)
        {
            return await _userService.Login(LoginTypeEnum.Google, googleLoginData.UserId, googleLoginData.AccessToken);
        }

        [HttpGet]
        [Route("rightmove/{locationIdentifier}/sortType/{sortType}/index/{index}/tenure/{tenure}")]
        public object TestApi(string locationIdentifier, string sortType, int index, string tenure)
        {
            return _userService.TryApiCall(locationIdentifier, sortType, index, tenure);
        }
    }
}
