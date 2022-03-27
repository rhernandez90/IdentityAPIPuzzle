﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.AuthenticationService.Dto
{
    public class UserDto
    {
        public  DateTimeOffset? LockoutEnd { get; set; }
        public  bool TwoFactorEnabled { get; set; }
        public  bool PhoneNumberConfirmed { get; set; }
        public  string PhoneNumber { get; set; }
        public  string ConcurrencyStamp { get; set; }
        public  string SecurityStamp { get; set; }
        public  bool EmailConfirmed { get; set; }
        public  string NormalizedEmail { get; set; }
        public  string Email { get; set; }
        public  string NormalizedUserName { get; set; }
        public  string UserName { get; set; }
        public  string Id { get; set; }
        public  bool LockoutEnabled { get; set; }
        public  int AccessFailedCount { get; set; }
        public List<string> Roles { get; set; }
    }
}
