using IdentityAPIPuzzle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.MenuCategoryService
{
    public interface IMenuCategoryService
    {
        Task<List<MenuCategory>> GetMenuCategoryThree();
        Task<List<MenuCategoryListDto>> GetAll();
    }
}
