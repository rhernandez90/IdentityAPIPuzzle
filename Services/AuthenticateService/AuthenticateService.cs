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
            return await PopulateUserDataAsync(userEntity);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = userManager.Users;
            return await PopulateUserDataAsync(users);
        }

        public async Task<UserDto> GetByIdAsync(string Id)
        {
            var user =await userManager.FindByIdAsync(Id);
            return await PopulateUserDataAsync(user);
        }

        public UserDto GetById(string Id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == Id);
            return  PopulateUserData(user);
        }

        public async Task Remove(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
                await userManager.DeleteAsync(user);
            else
                throw new AppException("User doesn't exist");
        }



    }
}
