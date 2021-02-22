using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class PermissionViewModel
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual List<PermissionCategoryMemberViewModel> PermissionCategoryMembers { get; set; }
    }
}