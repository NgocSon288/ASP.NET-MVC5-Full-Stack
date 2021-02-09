using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string PassWord { get; set; }

        public bool IsRememberMe { get; set; }
    }
}