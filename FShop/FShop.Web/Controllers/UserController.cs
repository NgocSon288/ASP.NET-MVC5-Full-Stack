using FShop.Common;
using FShop.Common.ModelSession;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IPermissionCategoryMemberService _permissionCategoryMemberService;

        public UserController(IMemberService memberService, IPermissionCategoryMemberService permissionCategoryMemberService)
        {
            this._memberService = memberService;
            this._permissionCategoryMemberService = permissionCategoryMemberService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model)
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

                    return RedirectToRoute("HomeClient");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session[Constants.MEMBER_SESSION] = null;

            return RedirectToAction("Index", "User");
        }

        private List<string> GetPermissions(int permissionCategoryMemberID)
        {
            var data = _permissionCategoryMemberService.GetPermissionCategoryMembers(permissionCategoryMemberID).ToList();
            var result = data.Select(p => p.PermissionID);
            return result.ToList();
        }
    }
}