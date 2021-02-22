using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class PermissionCategoryMemberViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CategoryMemberID { get; set; }

        [Required]
        public string PermissionID { get; set; }

        public PermissionViewModel Permission { get; set; }

        public CategoryMemberViewModel CategoryMember { get; set; }
    }
}