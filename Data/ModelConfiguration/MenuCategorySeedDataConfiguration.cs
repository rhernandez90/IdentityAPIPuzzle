using IdentityAPIPuzzle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Data.ModelConfiguration
{
    public class MenuCategorySeedDataConfiguration : IEntityTypeConfiguration<MenuCategory>
    {
        public void Configure(EntityTypeBuilder<MenuCategory> builder)
        {
            var MenuCategory = new MenuCategory()
            {
                Id = -1,
                Description = "Menu 1",
                MainCategory = true,
            };
            builder.HasData(MenuCategory);
        }
    }
}
