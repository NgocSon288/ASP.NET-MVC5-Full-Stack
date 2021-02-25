using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("PermissionCategoryMember")]
    public class PermissionCategoryMemberController : BaseAdminController
    {
        private readonly IPermissionCategoryMemberService _permissionCategoryMemberService;
        private readonly IPermissionService _permissionService;
        private readonly ICategoryMemberService _categoryMemberService;

        public PermissionCategoryMemberController(
            IPermissionCategoryMemberService permissionCategoryMemberService,
            IPermissionService permissionService,
            ICategoryMemberService categoryMemberService)
        {
            this._permissionCategoryMemberService = permissionCategoryMemberService;
            this._permissionService = permissionService;
            this._categoryMemberService = categoryMemberService;
        }

        // GET: Admin/PermissionCategoryMember
        public ActionResult Index()
        {
            ViewBag.permissions = AutoMapper.Mapper.Map<List<PermissionViewModel>>(_permissionService.GetAll());
            ViewBag.categoryMembers = AutoMapper.Mapper.Map<List<CategoryMemberViewModel>>(_categoryMemberService.GetAll());

            return View(AutoMapper.Mapper.Map<List<PermissionCategoryMemberViewModel>>(_permissionCategoryMemberService.GetAll()));
        }

        [HttpPost]
        public ActionResult InsertOrDelete(string permissionID, int categoryMemberID)
        {
            try
            {
                var permissionCategoryMember = new PermissionCategoryMember();

                permissionCategoryMember.CategoryMemberID = categoryMemberID;
                permissionCategoryMember.PermissionID = permissionID;

                if (_permissionCategoryMemberService.InsertOrDelete(permissionCategoryMember))
                {
                    _permissionCategoryMemberService.SaveChanges();

                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}