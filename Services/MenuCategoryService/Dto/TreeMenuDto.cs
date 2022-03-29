using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Services.MenuCategoryService.Dto
{
    public class TreeMenuDto
    {
        public string title { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        public List<TreeMenuDto> children { get; set; }


        public TreeMenuDto()
        {
            children = new List<TreeMenuDto>();
        }
    }
}
