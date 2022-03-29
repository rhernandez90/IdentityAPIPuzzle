using IdentityAPIPuzzle.Services.Dto;
using IdentityAPIPuzzle.Services.MenuCategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MenucategoryController : ControllerBase
    {

        private readonly IMenuCategoryService _menuCategoryService;
        public MenucategoryController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("/menucategories/")]
        public async Task<IActionResult> Create([FromBody] MenuCategoryDto model)
        {
            var newUser = await _menuCategoryService.Create(model);
            return Ok(newUser);
        }


        [AllowAnonymous]
        [HttpGet("/menucategories/menuthree")]
        public async Task<IActionResult> GetMenuThree()
        {
            var menu = await _menuCategoryService.GetTreeMenu();
            return Ok(menu);
        }

        [AllowAnonymous]
        [HttpGet("/menucategories/")]
        public async Task<IActionResult> GetAll()
        {
            var menu = await _menuCategoryService.GetAll();
            return Ok(menu);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("/menucategories/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _menuCategoryService.Remove(id);
            return Ok();            
            
        }
    }
}
