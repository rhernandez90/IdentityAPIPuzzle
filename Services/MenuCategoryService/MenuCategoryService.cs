using IdentityAPIPuzzle.Data;
using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Helpers;
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
            _context = context;
            hcontext = haccess.HttpContext;
        }

        public async Task<MenuCategoryDto> Create(MenuCategoryDto MenuCategory)
        {
            var menu = CreateMenuCategoryEntity(MenuCategory);
            await _context.AddAsync(menu);
            await _context.SaveChangesAsync();
            return PopulateMenuCategoryData(menu);
        }

        public async Task<List<MenuCategory>> GetMenuCategoryTree()
        {
            var menus =  await _context.MenuCategory.ToListAsync();
            return menus.Where(x => x.MainCategory).ToList();
                
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

        public async Task<List<MenuCategoryListDto>> GetAll()
        {
            var menu = _context.MenuCategory
                .Include(x => x.ParentCategory)
                .Select(x => new MenuCategoryListDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    MainCategory = x.MainCategory,
                    ParentMenu = x.ParentCategory.Description ?? "",
                    Role = x.Role
                });
            return await menu.ToListAsync();
        }

        public async Task Remove(int Id)
        {
            var user = await _context.MenuCategory.FindAsync(Id);
            if (user != null)
                 _context.MenuCategory.Remove(user);
            else
                throw new Exception("User doesn't exist");
        }




    }
}
