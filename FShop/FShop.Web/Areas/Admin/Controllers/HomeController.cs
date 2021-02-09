using FShop.Common;
using FShop.Common.ModelSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var member = GetMemberSession();
            return View();
        }
         
        [HttpGet]
        public ActionResult Logout()
        {
            DeleteMemberSession();

            return RedirectToAction("Index", "Login");
        }
    }
}