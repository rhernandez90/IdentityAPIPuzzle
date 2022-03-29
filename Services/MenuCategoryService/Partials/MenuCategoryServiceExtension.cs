using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Services.Dto;
using IdentityAPIPuzzle.Services.MenuCategoryService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.MenuCategoryService
{ 
    public partial class MenuCategoryService
    {

        public MenuCategory CreateMenuCategoryEntity(MenuCategoryDto MenuCategory)
        {
            return new MenuCategory()
            {
                Description = MenuCategory.Description,
                Role = MenuCategory.MainCategory?MenuCategory.Role:"",
                MainCategory = MenuCategory.MainCategory,
                ParentCategoryId = MenuCategory.MainCategory != true ? MenuCategory.parentCategoryId : null
            };
        }

        public MenuCategoryDto PopulateMenuCategoryData(MenuCategory model)
        {
            return new MenuCategoryDto()
            {
                Id = model.Id,
                Description = model.Description,
                Role = model.Role,
                MainCategory = model.MainCategory,
                parentCategoryId = model.ParentCategoryId,
            };
        }

        public TreeMenuDto CreateMenuTree(MenuCategory menu)
        {
            var newTreeMenuItem = new TreeMenuDto()
            {
                title = menu.Description,
                link = "",
                icon = "",
            };

            if (menu.Children != null && menu.Children.Any())
            {
                foreach (var item in menu.Children)
                    newTreeMenuItem.children.Add(CreateMenuTree(item));
            }

            return newTreeMenuItem;
        }


    }
}
