using IdentityAPIPuzzle.Data;
using IdentityAPIPuzzle.Helpers;
using IdentityAPIPuzzle.Services.AuthenticateService.Dto;
using IdentityAPIPuzzle.Services.AuthenticationService.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
    public partial class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticateService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<UserLoginDto> Authenticate(string UserName, string Password)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var userData = await CreateToken(userRoles, user);
                return userData;
            }
            return null;          
        }

        public async Task<UserDto> Create(RegisterUserDto model)
        {
            await UserValidation(model);
            var userEntity = CreateUserEntity(model);
            await userManager.CreateAsync(userEntity);
            await userManager.AddToRoleAsync(userEntity, model.Role);
            return await PopulateUserData(userEntity);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = userManager.Users;
            return await PopulateUserDataAsync(users);
        }

        public async Task<UserDto> GetById(string Id)
        {
            
            var user =await userManager.FindByIdAsync(Id);
            return await PopulateUserData(user);
        }


        public async Task Remove(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
                await userManager.DeleteAsync(user);
            else
                throw new AppException("User doesn't exist");
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
