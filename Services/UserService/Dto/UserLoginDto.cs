using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.AuthenticationService.Dto
{
    public class UserLoginDto
    {
        public string Id { get; set; }
        public string Email{ get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Roles { get; set; }
    }
}
