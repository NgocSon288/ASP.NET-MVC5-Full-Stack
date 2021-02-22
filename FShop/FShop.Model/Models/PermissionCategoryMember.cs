using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("PermissionCategoryMembers")]
    public class PermissionCategoryMember
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CategoryMemberID { get; set; }

        [Required]
        public string PermissionID { get; set; }

        [ForeignKey("PermissionID")]
        public Permission Permission { get; set; }

        [ForeignKey("CategoryMemberID")]
        public CategoryMember CategoryMember { get; set; }
    }
}