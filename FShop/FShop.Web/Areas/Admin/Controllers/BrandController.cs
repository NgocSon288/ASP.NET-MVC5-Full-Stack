using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("Brand")]
    public class BrandController : BaseAdminController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<BrandViewModel>>(_brandService.GetAll()));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(BrandViewModel model)
        {
            try
            {
                if (model.ImageUpload == null)
                {
                    ModelState.AddModelError("Logo", "Logo không được bỏ trống");
                }

                if (ModelState.IsValid)
                {
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);

                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        model.Logo = fileName + extension;

                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Brand/"), model.Logo));

                        var brand = AutoMapper.Mapper.Map<Brand>(model);
                        brand.CreatedBy = "";
                        brand.CreatedDate = DateTime.Now;
                        brand.Status = true;
                        brand.UpdateBy = "";
                        brand.UpdatedDate = DateTime.Now;

                        _brandService.Insert(brand);
                        _brandService.SaveChanges();

                        return RedirectToAction("Index", "Brand");
                    }
                }
            }
            catch (Exception)
            {
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(AutoMapper.Mapper.Map<BrandViewModel>(_brandService.GetByID(id)));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(BrandViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var brand = _brandService.GetByID(model.ID);

                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);

                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        model.Logo = fileName + extension;

                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Brand/"), model.Logo));
                    }

                    brand.Logo = model.Logo;
                    brand.Name = model.Name;
                    brand.Description = model.Description;
                    brand.MetaKeyword = model.MetaKeyword;
                    brand.MetaDescription = model.MetaDescription;
                    brand.UpdateBy = "";
                    brand.UpdatedDate = DateTime.Now;

                    _brandService.Update(brand);
                    _brandService.SaveChanges();

                    return RedirectToAction("Index", "Brand");
                }
            }
            catch (Exception)
            {
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var brand = _brandService.GetByID(id);

                _brandService.Delete(brand);
                _brandService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}