using FShop.Common;
using FShop.Common.ModelSession;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Infrastructure.Extensions
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public List<string> Permissions { get; set; }

        // Nếu mở rộng phân quyền
        public List<string> CategoryMembers { get; set; }

        public CustomAuthorizeAttribute(string permission)
        {
            Permissions = permission.Split(',').ToList();
            CategoryMembers = new List<string>();
        }

        // Nếu mở rộng phân quyền
        public CustomAuthorizeAttribute(string permissions, string categoryMembers)
        {
            Permissions = permissions.Trim().Split(',').Select(p=>p.Trim()).ToList();
            CategoryMembers = categoryMembers.Trim().Split(',').Select(p=>p.Trim()).ToList();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Kiểm tra member có đăng nhập chưa
            var memberSession = httpContext.Session[Constants.MEMBER_SESSION] as MemberSession;
            var check = false;

            if (memberSession == null)
                return false;

            // Get các permission của member đó
            List<string> permissions = httpContext.Session[Constants.PERMISSION_SESSION] as List<string>;


            permissions.ForEach(p =>
            {
                if (Permissions.Contains(p))
                {
                    check = true;
                }
            });

            return check;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Nếu không có quyền thì chuyển đến trang theo URL này
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error401.cshtml"
            };
        }
    }
}