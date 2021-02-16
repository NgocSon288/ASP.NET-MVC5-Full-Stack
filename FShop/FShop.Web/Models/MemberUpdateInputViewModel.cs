using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class MemberUpdateInputViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Tài khoản")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string UserName { get; set; }
         
        [DisplayName("Mật khẩu hiện tại")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string OldPassWord { get; set; }

        [DisplayName("Mật khẩu mới")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string NewPassWord { get; set; }

        [NotMapped]
        [DisplayName("Xác nhận mật khẩu")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string ConfirmNewPassWord { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Tên")]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string Avatar { get; set; }

        public string IsAnotherIdentity { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Trạng thái thành viên")]
        public int MemberStatusID { get; set; }

        public MemberStatusViewModel MemberStatus { get; set; } 

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}