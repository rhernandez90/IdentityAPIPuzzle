using IdentityAPIPuzzle.Data;
using IdentityAPIPuzzle.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.MenuCategoryService
{
    public class MenuCategoryService : IMenuCategoryService
    {

        private ApplicationDbContext _context;

        public MenuCategoryService(
            ApplicationDbContext context
        )
        {
            _context = context;
        }


        public async Task<List<MenuCategory>> GetMenuCategoryThree()
        {
            return await _context.MenuCategory.ToListAsync();
                
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

    }
}
