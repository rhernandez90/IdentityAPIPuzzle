using IdentityAPIPuzzle.Data;
using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Helpers;
using IdentityAPIPuzzle.Repositories;
using IdentityAPIPuzzle.Services.Dto;
using IdentityAPIPuzzle.Services.MenuCategoryService.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.MenuCategoryService
{
    public partial class MenuCategoryService : IMenuCategoryService
    {

        private IMenuCategoryRepository _menuCategoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext _context;
        private HttpContext hcontext;


        public MenuCategoryService(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IHttpContextAccessor haccess
        )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._context = context;
            this.hcontext = haccess.HttpContext;
            this._menuCategoryRepository = new MenuCategoryRepository(_context);
        }

        public async Task<MenuCategoryDto> Create(MenuCategoryDto MenuCategory)
        {
            var menu = CreateMenuCategoryEntity(MenuCategory);
            await _menuCategoryRepository.Insert(menu);
            await _menuCategoryRepository.Save();
            return PopulateMenuCategoryData(menu);
        }

        public async Task<List<MenuCategoryListDto>> GetAll()
        {
            var menus = await _menuCategoryRepository.GetAll();
            return menus.ToList();
        }

        public async Task<List<TreeMenuDto>> GetTreeMenu()
        {
            var role = hcontext.User.Claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select( x=>x.Value).FirstOrDefault() ;

            var returnTreeMenu = new List<TreeMenuDto>();
            var menus =  await _context.MenuCategory.ToListAsync();
            foreach(var item in menus.Where(x => x.MainCategory))
            {
                if(role == "Admin" || role == item.Role)
                    returnTreeMenu.Add(CreateMenuTree(item));
            }
            return returnTreeMenu;
        }


        public async Task Remove(int Id)
        {
            _menuCategoryRepository.Delete(Id);
            await _menuCategoryRepository.Save();
        }

        public Task<List<MenuCategory>> GetMenuCategoryTree()
        {
            throw new NotImplementedException();
        }
    }
}
