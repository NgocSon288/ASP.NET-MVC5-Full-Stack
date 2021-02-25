using FShop.Common;
using FShop.Common.ModelSession;
using FShop.Service.Services;
using FShop.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IPermissionCategoryMemberService _permissionCategoryMemberService;

        public LoginController(IMemberService memberService, IPermissionCategoryMemberService permissionCategoryMemberService)
        {
            this._memberService = memberService;
            this._permissionCategoryMemberService = permissionCategoryMemberService;
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _memberService.Login(model.UserName, model.PassWord);

                if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không hợp lệ");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không hợp lệ");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa");
                }
                else
                {
                    var member = await _memberService.GetByUserName(model.UserName);

                    Session.Add(Constants.MEMBER_SESSION, AutoMapper.Mapper.Map<MemberSession>(member));
                    Session.Add(Constants.PERMISSION_SESSION, GetPermissions(member.CategoryMember.ID));

                    return RedirectToAction("Index", "Home");
                }
            }

            // dùng view mới validationg được dữ liệu
            return View("Index");
        }

        private List<string> GetPermissions(int permissionCategoryMemberID)
        {
            var data = _permissionCategoryMemberService.GetPermissionCategoryMembers(permissionCategoryMemberID).ToList();
            var result = data.Select(p => p.PermissionID);
            return result.ToList();
        }

    }
}