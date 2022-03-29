using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Services.Dto;
using IdentityAPIPuzzle.Services.MenuCategoryService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.MenuCategoryService
{
    public interface IMenuCategoryService
    {
        Task<MenuCategoryDto> Create(MenuCategoryDto MenuCategory);
        Task<List<MenuCategory>> GetMenuCategoryTree();
        Task<List<TreeMenuDto>> GetTreeMenu();
        Task<List<MenuCategoryListDto>> GetAll();
        Task Remove(int Id);
    }
}
