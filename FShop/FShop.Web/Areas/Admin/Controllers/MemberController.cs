using FShop.Service.Services;
using FShop.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class MemberController : BaseAdminController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            this._memberService = memberService;
        }

        // GET: Admin/Member
        public ActionResult Index()
        {
            var members = _memberService.GetAll().ToList();

            var memberVMs = AutoMapper.Mapper.Map<List<MemberViewModel>>(members);
            return View(memberVMs);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int memberID)
        {
            try
            {
                var member = _memberService.GetByID(memberID);
                member.MemberStatusID = member.MemberStatusID == 1 ? 3 : 1;

                _memberService.Update(member);
                _memberService.SaveChanges();

                return Content("1");
            }
            catch (System.Exception e)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult DeleteMember(int memberID)
        {
            try
            {
                _memberService.Delete(memberID);
                _memberService.SaveChanges();

                return Content("1");
            }
            catch (System.Exception e)
            {
                return Content("0");
            }
        }
    }
}