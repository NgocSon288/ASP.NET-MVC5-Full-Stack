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
    public class CategoryMemberController : BaseAdminController
    {
        private readonly ICategoryMemberService _categoryMemberService;

        public CategoryMemberController(ICategoryMemberService categoryMemberService)
        {
            this._categoryMemberService = categoryMemberService;
        }

        // GET: Admin/CategoryMember
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<CategoryMemberViewModel>>(_categoryMemberService.GetAll()));
        }

        [HttpPost]
        public ActionResult Add(string name, string description)
        {
            try
            {
                var category = new CategoryMember();

                category.Name = name;
                category.Description = description;

                _categoryMemberService.Insert(category);
                _categoryMemberService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult Update(int id, string name, string description)
        {
            try
            {
                var category = _categoryMemberService.GetByID(id);

                category.Name = name;
                category.Description = description;

                _categoryMemberService.Update(category);
                _categoryMemberService.SaveChanges();

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
                _categoryMemberService.Delete(id);
                _categoryMemberService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}