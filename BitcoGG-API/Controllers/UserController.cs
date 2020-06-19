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
        //Register
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
        //Login
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
        //Get user
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
        //Get all users
        public IActionResult GetAll(int id)
        {
            var service = _userService.GetAll(id);
            return Ok(service);
        }

        [HttpPost("{id}/delete")]
        //Delete user
        public IActionResult Delete([FromBody] int selectedId, int id)
        {
            _userService.Delete(selectedId, id);
            return Ok();
        }

        [HttpPost("{id}/CreateWallet")]
        //Create wallet
        public IActionResult CreateWallet(Wallet wallet, int id)
        {
            try
            {
                wallet.UserId = id;
                _userService.CreateWallet(wallet, id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPost("{id}/DeleteWallet")]
        //Delete wallet
        public IActionResult DeleteWallet([FromBody] Wallet wallet, int id)
        {
            try
            {
                _userService.DeleteWallet(wallet, id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }
        [HttpPost("{Id}/PurchaseCoin")]
        //Purchase a coin
        public IActionResult PurchaseCoin([FromBody] PurchasedCoin purchasedCoin, int Id)
        {
            try
            {
                _userService.PurchaseCoin(purchasedCoin, Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet("{id}/GetUserWallet")]
        //Get the users wallet
        public IActionResult GetPurchasedCoin(int id)
        {
            try
            {
                var service = _userService.GetPurchasedCoin(id);
                return Ok(service);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            
        }
        [HttpPost("{id}/UpdatePurchasedCoin")]
        //update purchased coin (Not working!)
        public IActionResult UpdatePurchasedCoin([FromBody] int selectedId, int id, int quantity)
        {
            _userService.UpdatePurchasedCoin(selectedId, id, quantity);
            return Ok();
        }
    }
}