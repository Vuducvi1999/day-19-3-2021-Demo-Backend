using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Service.Users;
using Domain.DTOs;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserDto searchModel)
        {
            var users = _userService.GetList(searchModel);
            return Ok(users);
        }

        [HttpPost("login")]
        [EnableCors("LoginCors")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            bool result = _userService.Login(model);
            return Ok(result);
        }
    }
}
