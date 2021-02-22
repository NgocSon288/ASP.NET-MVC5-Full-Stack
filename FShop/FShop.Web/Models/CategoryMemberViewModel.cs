using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class CategoryMemberViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<PermissionCategoryMemberViewModel> PermissionCategoryMembers { get; set; }

        public virtual List<MemberViewModel> Members { get; set; }
    }
}