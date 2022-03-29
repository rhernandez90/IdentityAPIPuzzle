using IdentityAPIPuzzle.Services.AuthenticateService.Dto;
using IdentityAPIPuzzle.Services.AuthenticationService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.AuthenticationService
{
    public interface IUserService
    {
        Task<UserLoginDto> Authenticate(string user, string password);
        Task<UserDto> Create(RegisterUserDto user);
        Task<UserDto> Update(RegisterUserDto model);
        Task<UserDto> GetByIdAsync(string Id);
        UserDto GetById(string Id);
        Task Remove(string Id);
        Task<List<UserDto>> GetAll();
    }
}
