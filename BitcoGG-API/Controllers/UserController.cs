using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BitcoGG_API.Models;
using BitcoGG_API.Services.Helpers;
using BitcoGG_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BitcoGG_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginUser user)
        {
            if (user.Username != "" && user.Password != "")
            {
                var jwtUser = _userService.Authenticate(user.Username, user.Password);
                if (jwtUser == null)
                {
                    return BadRequest();
                }

                jwtUser.User = jwtUser.User.WithoutPassword();
                jwtUser.User = jwtUser.User.WithoutAdmin();
                return Ok(jwtUser);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user.WithoutPassword());
        }

        [HttpGet( "{id}/all")]
        //[Authorize(Policy = "Admin")]
        public IActionResult GetAll(int id)
        {
            var service = _userService.GetAll(id);
            return Ok(service);
        }

        [HttpPost ("{id}/delete")]
        public IActionResult Delete([FromBody] int selectedId, int id)
        {
            _userService.Delete(selectedId, id);
            return Ok();
        }
    }
}