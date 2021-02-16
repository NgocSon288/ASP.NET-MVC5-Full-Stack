using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class MemberStatusController : BaseAdminController
    {
        private readonly IMemberStatusService _memberStatusService;

        public MemberStatusController(IMemberStatusService memberStatusService)
        {
            this._memberStatusService = memberStatusService;
        }

        // GET: Admin/MemberStatus
        public ActionResult Index()
        {
            var memberStatuses = _memberStatusService.GetAll().ToList();

            var model = AutoMapper.Mapper.Map<List<MemberStatusViewModel>>(memberStatuses);

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _memberStatusService.Delete(id);
                _memberStatusService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Add(string description, int status)
        {
            try
            {
                var memberStatus = new MemberStatus() { Description = description, Status = status };
                _memberStatusService.Insert(memberStatus);
                _memberStatusService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Update(int id, string description)
        {
            try
            {
                var memberStatus = _memberStatusService.GetByID(id);
                memberStatus.Description = description;

                _memberStatusService.Update(memberStatus);
                _memberStatusService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}