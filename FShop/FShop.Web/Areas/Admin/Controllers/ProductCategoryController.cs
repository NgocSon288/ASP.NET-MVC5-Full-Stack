using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseAdminController
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }

        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<ProductCategoryViewModel>>(_productCategoryService.GetAll()));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategoryViewModel model)
        {
            try
            {
                if (model.ImageUpload == null)
                {
                    ModelState.AddModelError("Icon", "Icon không được bỏ trống");
                }

                if (ModelState.IsValid)
                {
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);

                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        model.Icon = fileName + extension;

                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/ProductCategory/"), model.Icon));

                        var productCategory = AutoMapper.Mapper.Map<ProductCategory>(model);
                        productCategory.CreatedBy = "";
                        productCategory.CreatedDate = DateTime.Now;
                        productCategory.Status = true;
                        productCategory.UpdateBy = "";
                        productCategory.UpdatedDate = DateTime.Now;

                        _productCategoryService.Insert(productCategory);
                        _productCategoryService.SaveChanges();

                        return RedirectToAction("Index", "ProductCategory");
                    }
                }
            }
            catch (Exception e)
            {
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(AutoMapper.Mapper.Map<ProductCategoryViewModel>(_productCategoryService.GetByID(id)));
        }

        [HttpPost]
        public ActionResult Update(ProductCategoryViewModel model)
        { 
            if (ModelState.IsValid)
            {
                var productCategory = _productCategoryService.GetByID(model.ID);

                if (model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);

                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    model.Icon = fileName + extension; 

                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/ProductCategory/"), model.Icon));
                }

                productCategory.Icon = model.Icon;
                productCategory.MetaDescription = model.MetaKeyword;
                productCategory.MetaDescription = model.MetaDescription;
                productCategory.Name = model.Name;
                productCategory.UpdateBy = "";
                productCategory.UpdatedDate = DateTime.Now;
                productCategory.Description = model.Description;
                productCategory.Alias = model.Alias;

                _productCategoryService.Update(productCategory);
                _productCategoryService.SaveChanges();


                return RedirectToAction("Index", "ProductCategory");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _productCategoryService.Delete(id);
                _productCategoryService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}