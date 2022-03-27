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
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _menuCategoryService.GetMenuCategoryThree());
        }
    }
}
