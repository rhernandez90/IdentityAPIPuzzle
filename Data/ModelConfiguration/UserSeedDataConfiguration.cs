using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Models.ModelConfiguration
{
    public class UserSeedDataConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var user = new IdentityUser()
            {
                Id = "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                AccessFailedCount = 3,
                UserName = "administrator",
                NormalizedUserName = "administrator",
                Email = "rhernandezmunugia@gmail.com",
                NormalizedEmail = "rhernandezmunguia@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                
            };

            var password = new PasswordHasher<IdentityUser>();
            var hashed = password.HashPassword(user, "123qwe");
            user.PasswordHash = hashed;
            builder.HasData(user);
        }
    }
}
