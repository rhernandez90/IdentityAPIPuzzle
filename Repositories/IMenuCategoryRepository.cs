using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Services.MenuCategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Repositories
{
    public interface IMenuCategoryRepository
    {
        Task<IEnumerable<MenuCategoryListDto>> GetAll();
        Task<MenuCategory> GetById(int menuId);
        Task Insert(MenuCategory menuCategory);
        void Update(MenuCategory menuCategory);
        void Delete(int menuId);
        Task Save();
    }
}
