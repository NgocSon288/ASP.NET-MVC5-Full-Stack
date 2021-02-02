using FShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Members")]
    public class Member : Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Tài khoản")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Mật khẩu")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string PassWord { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public string Avatar { get; set; }

        public string IsAnotherIdentity { get; set; }

        [Required]
        public int MemberStatusID { get; set; }

        [ForeignKey("MemberStatusID")]
        public virtual MemberStatus MemberStatus { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual IEnumerable<MemberNotification> MemberNotifications { get; set; }
    }
}