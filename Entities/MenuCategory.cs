using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPIPuzzle.Entities
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public Boolean MainCategory { get; set; }
        public String Description { get; set; }
        public string Role { get; set;}

        [ForeignKey("ParentMenuCategory")]
        public int? ParentCategoryId { get; set; }

        public MenuCategory ParentCategory { get; set; }
        public ICollection<MenuCategory> Children { get; set; }

    }
}
