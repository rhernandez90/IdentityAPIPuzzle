using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.Dto
{
    public class MenuCategoryDto
    {
        public int Id { get; set; }
        public Boolean MainCategory { get; set; }
        public String Description { get; set; }
        public string ParentMenu { get; set; }
        public int? parentCategoryId { get; set; }
        public string Role { get; set; }
    }
}
