using FShop.Common;
using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ISupplierService _supplierService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(
            IProductService productService,
            IBrandService brandService,
            ISupplierService supplierService,
            IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._brandService = brandService;
            this._supplierService = supplierService;
            this._productCategoryService = productCategoryService;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetAll()));
        }

        [HttpGet]
        public PartialViewResult ProductListPartial(string key = "", int page = 1, int pageSize = 3, int installment = 0, int brandID = 0, int supplierID = 0, int categoryID = 0)
        {
            var data = _productService.GetProductPage(key, page, pageSize, out int pageMax, installment, brandID, supplierID, categoryID);
            var result = AutoMapper.Mapper.Map<List<ProductViewModel>>(data);

            ViewBag.key = key;
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            ViewBag.pageMax = pageMax;
            ViewBag.installment = installment;
            ViewBag.brandID = brandID;
            ViewBag.supplierID = supplierID;
            ViewBag.categoryID = categoryID;

            var brands = AutoMapper.Mapper.Map<List<BrandViewModel>>(_brandService.GetAll());
            var suppliers = AutoMapper.Mapper.Map<List<SupplierViewModel>>(_supplierService.GetAll());
            var productCategories = AutoMapper.Mapper.Map<List<ProductCategoryViewModel>>(_productCategoryService.GetAll());

            ViewBag.brands = brands;
            ViewBag.suppliers = suppliers;
            ViewBag.productCategories = productCategories;

            return PartialView(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Setup();

            return View();
        }

        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(ProductViewModel model, List<HttpPostedFileBase> imageFileList, List<string> txtLabel, List<string> txtContent)
        {
            try
            {
                txtLabel.RemoveAt(0);
                txtContent.RemoveAt(0);
                model.Content = ConvertToContent(txtLabel, txtContent);
                model.Image = "";
                model.MoreImage = "";

                if (!_productService.IsDisplayNameOk(model.Name))
                {
                    ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại");
                }

                if (!_productService.IsAliasOk(model.Alias))
                {
                    ModelState.AddModelError("Alias", "Alias sản phẩm đã tồn tại");
                }

                if (imageFileList == null || imageFileList.Count <= 0 || imageFileList[0] == null)
                {
                    ModelState.AddModelError("Image", "Hình ảnh không được bỏ trống");
                }

                if (ModelState.IsValid)
                {
                    for (int i = 0; i < imageFileList.Count; i++)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(imageFileList[i].FileName);
                        string extension = Path.GetExtension(imageFileList[i].FileName);
                        string fileFullName = model.Alias + "-" + fileName + extension;

                        if (model.Image.Contains(fileFullName) || model.MoreImage.Contains(fileFullName))
                        {
                            continue;
                        }

                        if (i == 0)
                        {
                            model.Image = fileFullName;
                        }
                        else
                        {
                            model.MoreImage += fileFullName + Constants.IMAGE_CHAR;
                        }

                        imageFileList[i].SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Product/"), fileFullName));
                    }

                    var product = AutoMapper.Mapper.Map<Product>(model);
                    product.CreatedBy = "";
                    product.CreatedDate = DateTime.Now;
                    product.Status = true;
                    product.UpdateBy = "";
                    product.UpdatedDate = DateTime.Now;
                    product.BuyCount = 0;
                    product.Rating = 0;
                    product.ViewCount = 0;
                    product.Count = 0;

                    if (product.MoreImage.Length > 0)
                    {
                        product.MoreImage = product.MoreImage.Substring(0, product.MoreImage.Length - 1);
                    }

                    _productService.Insert(product);
                    _productService.SaveChanges();

                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception e)
            {
                Setup();
                return View(model);
            }

            Setup();
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var product = AutoMapper.Mapper.Map<ProductViewModel>(_productService.GetByID(id));

            Setup();

            return View(product);
        }

        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(ProductViewModel model, List<HttpPostedFileBase> imageFileList, List<string> imageList, List<string> txtLabel, List<string> txtContent)
        {
            try
            {
                txtLabel.RemoveAt(0);
                txtContent.RemoveAt(0);
                model.Content = ConvertToContent(txtLabel, txtContent);

                if (!_productService.IsDisplayNameOk(model.Name, model.ID))
                {
                    ModelState.AddModelError("Name", "Tên sản phẩm đã tồn tại");
                }

                if (!_productService.IsAliasOk(model.Alias, model.ID))
                {
                    ModelState.AddModelError("Alias", "Alias sản phẩm đã tồn tại");
                }

                if (ModelState.IsValid)
                {
                    var product = _productService.GetByID(model.ID);

                    for (int i = 0; i < imageFileList.Count; i++)
                    {
                        if (imageFileList[i] != null)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(imageFileList[i].FileName);
                            string extension = Path.GetExtension(imageFileList[i].FileName);
                            string fileFullName = model.Alias + "-" + fileName + extension;

                            if (model.Image.Contains(fileFullName) || model.MoreImage.Contains(fileFullName))
                            {
                                continue;
                            }

                            imageList.Add(fileFullName);

                            imageFileList[i].SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Product/"), fileFullName));
                        }
                    }

                    model.Image = "";
                    model.MoreImage = "";

                    for (int i = 0; i < imageList.Count; i++)
                    {
                        if (i == 0)
                        {
                            model.Image = imageList[i];
                        }
                        else
                        {
                            model.MoreImage += imageList[i] + Constants.IMAGE_CHAR;
                        }
                    }

                    product.UpdateBy = "";
                    product.UpdatedDate = DateTime.Now;
                    product.Image = model.Image;
                    product.Name = model.Name;
                    product.Alias = model.Alias;
                    product.Price = model.Price;
                    product.Promotion = model.Promotion;
                    product.MoreImage = model.MoreImage.Substring(0, model.MoreImage.Length - 1);
                    product.Description = model.Description;
                    product.Content = model.Content;
                    product.IsFreeShip = model.IsFreeShip;
                    product.IsInstallment = model.IsInstallment;
                    product.MetaKeyword = model.MetaDescription;
                    product.BrandID = model.BrandID;
                    product.SupplierID = model.SupplierID;
                    product.CategoryID = model.CategoryID;

                    _productService.Update(product);
                    _productService.SaveChanges();

                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception e)
            {
                Setup();
                return View(model);
            }

            Setup();
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool status)
        {
            try
            {
                var product = _productService.GetByID(id);
                product.Status = status;

                _productService.Update(product);
                _productService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }

        #region Method

        private string ConvertToContent(List<string> label, List<string> content)
        {
            try
            {
                var count = label.Count;
                var result = "";

                for (int i = 0; i < count; i++)
                {
                    if (label[i] != "" || content[i] != "")
                    {
                        result += label[i] + Constants.BETWEEN_CHAR + content[i] + Constants.END_CHAR;
                    }
                }

                return result.Substring(0, result.Length - 1);
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void Setup()
        {
            var brands = AutoMapper.Mapper.Map<List<BrandViewModel>>(_brandService.GetAll());
            var suppliers = AutoMapper.Mapper.Map<List<SupplierViewModel>>(_supplierService.GetAll());
            var productCategories = AutoMapper.Mapper.Map<List<ProductCategoryViewModel>>(_productCategoryService.GetAll());

            SelectList brandSL = new SelectList(brands, "ID", "Name");
            SelectList supplierSL = new SelectList(suppliers, "ID", "Name");
            SelectList productCategorySL = new SelectList(productCategories, "ID", "Name");

            ViewBag.brandSL = brandSL;
            ViewBag.supplierSL = supplierSL;
            ViewBag.productCategorySL = productCategorySL;
        }

        #endregion Method
    }
}