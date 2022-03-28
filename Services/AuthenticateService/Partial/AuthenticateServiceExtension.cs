using IdentityAPIPuzzle.Helpers;
using IdentityAPIPuzzle.Services.AuthenticateService.Dto;
using IdentityAPIPuzzle.Services.AuthenticationService.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
            var hashed = password.HashPassword(user, model.Password);
            user.PasswordHash = hashed;

            return user;
        }
        public UserDto PopulateUserData(IdentityUser model)
        {
            if (model == null)
                return null;

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
            };
            return user;
        }
        public async Task<UserDto> PopulateUserDataAsync(IdentityUser model)
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
                Roles = string.Join(", ", roles.ToList()) 
            };
            return user;
        }
        public async Task<List<UserDto>> PopulateUserDataAsync(IQueryable<IdentityUser> usersEntity)
        {

            var users = new List<UserDto>();
            foreach (var model in usersEntity)
            {
               var userDto = new UserDto()
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
               };
               userDto.Roles = string.Join(", ", (await userManager.GetRolesAsync(model)).ToList()) ;
               users.Add(userDto);
           };
           return users;
        }
        protected async Task<UserLoginDto> CreateToken(IList<string> roles, IdentityUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Id));
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // authentication successful
            var userDto = new UserLoginDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = tokenString,
                Roles = string.Join(", ", roles),
                Email = user.Email
            };

            return userDto;
        }
        private async Task<bool> UserValidation(RegisterUserDto UserData)
        {
            var user = await userManager.FindByNameAsync(UserData.UserName);
            var role = await roleManager.FindByNameAsync(UserData.Role);

            if (string.IsNullOrWhiteSpace(UserData.UserName))
                throw new AppException("User is required");

            if (string.IsNullOrWhiteSpace(UserData.Password))
                throw new AppException("Password is required");

            if (user != null)
                throw new AppException("Username \"" + UserData.UserName + "\" is already taken");

            if (role == null)
                throw new AppException("Role '" + UserData.Role + "' does not exist");

            return true;
        }

    }
}
