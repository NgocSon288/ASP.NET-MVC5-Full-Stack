using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("CategoryNotification")]
    public class CategoryNotificationController : BaseAdminController
    {
        private readonly ICategoryNotificationService _categoryNotificationService;

        public CategoryNotificationController(ICategoryNotificationService categoryNotificationService)
        {
            this._categoryNotificationService = categoryNotificationService;
        }

        // GET: Admin/CategoryNotification
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<CategoryNotificationViewModel>>(_categoryNotificationService.GetAll().ToList()));
        }

        [HttpPost]
        public ActionResult Add(string description, string color, string icon)
        {
            try
            {
                var category = new CategoryNotification();

                category.Description = description;
                category.Color = color;
                category.Icon = icon;

                _categoryNotificationService.Insert(category);
                _categoryNotificationService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Update(int id, string description, string color, string icon)
        {
            try
            {
                var category = _categoryNotificationService.GetByID(id);

                category.Description = description;
                category.Color = color;
                category.Icon = icon;

                _categoryNotificationService.Update(category);
                _categoryNotificationService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryNotificationService.Delete(id);
                _categoryNotificationService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}