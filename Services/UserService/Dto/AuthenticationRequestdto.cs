using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.AuthenticationService.Dto
{
    public class AuthenticationRequestdto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
