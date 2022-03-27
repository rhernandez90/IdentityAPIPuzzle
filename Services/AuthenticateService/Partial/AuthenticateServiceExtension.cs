using IdentityAPIPuzzle.Services.AuthenticateService.Dto;
using IdentityAPIPuzzle.Services.AuthenticationService.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.AuthenticationService
{
    public partial class AuthenticateService
    {

        public IdentityUser CreateUserEntity(RegisterUserDto model)
        {
            var user =  new IdentityUser(){
                AccessFailedCount = 3,
                UserName = model.UserName,
                NormalizedUserName = model.UserName.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var password = new PasswordHasher<IdentityUser>();
            var hashed = password.HashPassword(user, "123qwe");
            user.PasswordHash = hashed;

            return user;
        }

        public async Task<UserDto> PopulateUserData(IdentityUser model)
        {
            if (model == null)
                return null;

            var roles = await userManager.GetRolesAsync(model);
            var user = new UserDto()
            {
                Id = model.Id,
                AccessFailedCount = model.AccessFailedCount,
                UserName = model.UserName,
                NormalizedUserName = model.UserName,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                EmailConfirmed = model.EmailConfirmed,
                LockoutEnabled = model.LockoutEnabled,
                SecurityStamp = model.SecurityStamp,
                PhoneNumber = model.PhoneNumber,
                ConcurrencyStamp = model.ConcurrencyStamp,
                TwoFactorEnabled = model.TwoFactorEnabled,
                LockoutEnd = model.LockoutEnd,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed,
                Roles = roles.ToList()
            };
            return user;
        }

        public async Task<List<UserDto>> PopulateUserDataAsync(IQueryable<IdentityUser> usersEntity)
        {
            var user = await usersEntity.Select( model =>  new UserDto()
            {
                Id = model.Id,
                AccessFailedCount = model.AccessFailedCount,
                UserName = model.UserName,
                NormalizedUserName = model.UserName,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                EmailConfirmed = model.EmailConfirmed,
                LockoutEnabled = model.LockoutEnabled,
                SecurityStamp = model.SecurityStamp,
                PhoneNumber = model.PhoneNumber,
                ConcurrencyStamp = model.ConcurrencyStamp,
                TwoFactorEnabled = model.TwoFactorEnabled,
                LockoutEnd = model.LockoutEnd,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed,
            }).ToListAsync();
            return user;
        }

    }
}
