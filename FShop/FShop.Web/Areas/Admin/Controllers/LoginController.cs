using FShop.Common;
using FShop.Common.ModelSession;
using FShop.Service.Services;
using FShop.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMemberService _memberService;

        public LoginController(IMemberService memberService)
        {
            this._memberService = memberService;
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

                    return RedirectToAction("Index", "Home");
                }
            }

            // dùng view mới validationg được dữ liệu
            return View("Index");
        }
         
    }
}