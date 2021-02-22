using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual IEnumerable<PermissionCategoryMember> PermissionCategoryMembers { get; set; }
    }
}