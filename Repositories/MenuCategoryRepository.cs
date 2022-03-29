using IdentityAPIPuzzle.Data;
using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Services.MenuCategoryService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Repositories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly ApplicationDbContext _context;


        public MenuCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuCategoryListDto>> GetAll()
        {
            return await _context.MenuCategory
                .Include(x => x.ParentCategory)
                .Select(x => new MenuCategoryListDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    MainCategory = x.MainCategory,
                    ParentMenu = x.ParentCategory.Description ?? "",
                    Role = x.Role
                }).ToListAsync();
        }

        public async Task<MenuCategory> GetById(int menuId)
        {
            return await _context.MenuCategory.FindAsync(menuId);
        }

        public async Task Insert(MenuCategory menuCategory)
        {
            await _context.MenuCategory.AddAsync(menuCategory);
        }

        public void Update(MenuCategory menuCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int menuId)
        {
            var menu =  _context.MenuCategory.Find(menuId);
            _context.MenuCategory.Remove(menu);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
