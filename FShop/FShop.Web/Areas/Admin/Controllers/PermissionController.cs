using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class PermissionController : BaseAdminController
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService PermissionService)
        {
            this._permissionService = PermissionService;
        }

        // GET: Admin/Permission
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<PermissionViewModel>>(_permissionService.GetAll()));
        }

        [HttpPost]
        public ActionResult Add(string id, string name, string description)
        {
            try
            {
                var permission = new Permission();

                permission.ID = id;
                permission.Name = name;
                permission.Description = description;

                _permissionService.Insert(permission);
                _permissionService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Update(string id, string name, string description)
        {
            try
            {
                var permission = _permissionService.GetAll().FirstOrDefault(p => p.ID == id);

                permission.Name = name;
                permission.Description = description;

                _permissionService.Update(permission);
                _permissionService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                _permissionService.Delete(_permissionService.GetAll().FirstOrDefault(p => p.ID == id));
                _permissionService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}