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
    public class MenucategoryController : ControllerBase
    {

        private readonly IMenuCategoryService _menuCategoryService;
        public MenucategoryController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        [AllowAnonymous]
        [HttpGet("/menucategories/menuthree")]
        public async Task<IActionResult> GetMenuThree()
        {
            var menu = await _menuCategoryService.GetMenuCategoryThree();
            return Ok(menu);
        }

        [AllowAnonymous]
        [HttpGet("/menucategories/")]
        public async Task<IActionResult> GetAll()
        {
            var menu = await _menuCategoryService.GetAll();
            return Ok(menu);
        }
    }
}
