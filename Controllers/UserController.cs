using IdentityAPIPuzzle.Services.AuthenticateService.Dto;
using IdentityAPIPuzzle.Services.AuthenticationService;
using IdentityAPIPuzzle.Services.AuthenticationService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private  IUserService _autheticationService;

        public UserController(IUserService autheticationService)
        {
            _autheticationService = autheticationService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestdto model)
        {
            var user = await _autheticationService.Authenticate(model.UserName, model.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

      
        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto UserData)
        {
            var newUser = await _autheticationService.Create(UserData);
            return Ok(newUser);            
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("/user")]
        public async Task<IActionResult> UpdateUser([FromBody] RegisterUserDto UserData)
        {
            var newUser = await _autheticationService.Update(UserData);
            return Ok(newUser);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/user")]
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _autheticationService.GetAll();
            return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var user = await _autheticationService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("/user/{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _autheticationService.Remove(id);
            return Ok();
        }

    }


}
