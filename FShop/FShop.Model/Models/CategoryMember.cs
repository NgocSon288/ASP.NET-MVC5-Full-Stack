using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("CategoryMembers")]
    public class CategoryMember
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual IEnumerable<PermissionCategoryMember> PermissionCategoryMembers { get; set; }

        public virtual IEnumerable<Member> Members { get; set; }
    }
}