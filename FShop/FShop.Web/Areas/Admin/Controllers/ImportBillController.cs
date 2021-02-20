using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class ImportBillController : BaseAdminController
    {
        private readonly IImportBillService _importBillService;
        private readonly IImportBillDetailService _importBillDetailService;
        private readonly IProductService _productService;
        private object product;

        public ImportBillController(
            IImportBillService importBillService,
            IImportBillDetailService importBillDetailService,
            IProductService productService)
        {
            this._importBillService = importBillService;
            this._importBillDetailService = importBillDetailService;
            this._productService = productService;
        }

        // GET: Admin/ImportBill
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ImportBillListPartial(int page = 1, int pageSize = 3, DateTime? startDate = null, DateTime? endDate = null)
        {
            var data = _importBillService.GetImportBillPage(page, pageSize, out int pageMax, startDate, endDate);
            var result = AutoMapper.Mapper.Map<List<ImportBillViewModel>>(data);

            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            ViewBag.pageMax = pageMax;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            return PartialView(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Products = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetAll().ToList().Where(p => p.Status.Value));

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(List<ImportBillDetailViewModel> modelDetail)
        {
            try
            {
                var importBill = new ImportBill();
                importBill.CreatedBy = GetMemberSession().DisplayName;
                importBill.CreatedDate = DateTime.Now;
                importBill.Status = true;
                importBill.UpdateBy = "";
                importBill.UpdatedDate = null;

                // Add ImportBill
                _importBillService.Insert(importBill);
                _importBillService.SaveChanges();

                // Add ImportBillDetail
                modelDetail.ForEach(bd => bd.ImportBillID = importBill.ID);

                _importBillDetailService.Insert(AutoMapper.Mapper.Map<List<ImportBillDetail>>(modelDetail));
                _importBillDetailService.SaveChanges();

                // Update ProductCount
                modelDetail.ForEach(bd =>
                {
                    var product = _productService.GetByID(bd.ProductID);

                    product.Count += bd.Count;
                });
                _productService.SaveChanges();

                return RedirectToAction("Index", "ImportBill");
            }
            catch (Exception)
            {
            }

            ViewBag.Products = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetAll());
            ViewBag.modelDetail = modelDetail;

            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = AutoMapper.Mapper.Map<ImportBillViewModel>(_importBillService.GetByID(id));

            ViewBag.Products = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetAll());

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ImportBill model, List<ImportBillDetailViewModel> modelDetail)
        {
            try
            {
                var importBill = _importBillService.GetByID(model.ID);
                var newBill = new ImportBill();

                // Update ProductCount
                importBill.ImportBillDetails.ToList().ForEach(bd =>
                {
                    var product = _productService.GetByID(bd.ProductID);

                    product.Count -= bd.Count;
                });

                modelDetail = modelDetail.Where(ibd => ibd.ProductID != 0).ToList();
                modelDetail.ForEach(bd =>
                {
                    var product = _productService.GetByID(bd.ProductID);

                    product.Count += bd.Count;
                });

                _productService.SaveChanges();

                // Delete all ImportBillDetail
                _importBillDetailService.DeleteByImportBillID(importBill.ID);
                _importBillDetailService.SaveChanges();

                // Delete ImportBillOld and Create ImportBillNew
                newBill.CreatedBy = importBill.CreatedBy;
                newBill.CreatedDate = importBill.CreatedDate;
                newBill.Status = importBill.Status;
                newBill.UpdateBy = GetMemberSession().DisplayName;
                newBill.UpdatedDate = DateTime.Now;

                _importBillService.Delete(importBill);
                _importBillService.Insert(newBill);
                _importBillService.SaveChanges();

                // Add ImportBillDetail
                modelDetail.ForEach(bd => bd.ImportBillID = newBill.ID);

                _importBillDetailService.Insert(AutoMapper.Mapper.Map<List<ImportBillDetail>>(modelDetail));
                _importBillDetailService.SaveChanges();

                return RedirectToAction("Index", "ImportBill");
            }
            catch (Exception e)
            {
            }

            ViewBag.Products = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetAll());
            ViewBag.modelDetail = modelDetail;

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, bool status)
        {
            try
            {
                var import = _importBillService.GetByID(id);
                import.Status = status;

                _importBillService.Update(import);
                _importBillService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}