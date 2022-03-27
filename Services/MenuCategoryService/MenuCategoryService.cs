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

    }
}
