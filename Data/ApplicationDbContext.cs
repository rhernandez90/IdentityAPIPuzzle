using IdentityAPIPuzzle.Data.ModelConfiguration;
using IdentityAPIPuzzle.Entities;
using IdentityAPIPuzzle.Models.ModelConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserSeedDataConfiguration());
            builder.ApplyConfiguration(new RoleSeedDataConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedDataConfiguration());
            builder.ApplyConfiguration(new MenuCategorySeedDataConfiguration());

            builder.Entity<MenuCategory>()
                                  .HasOne(b => b.ParentCategory)
                                  .WithMany(b => b.Children)
                                  .HasForeignKey(b => b.ParentCategoryId);
        }

        public DbSet<MenuCategory> MenuCategory { get; set; }
    
    }
}
