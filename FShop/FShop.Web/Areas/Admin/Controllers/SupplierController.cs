using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class SupplierController : BaseAdminController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }

        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<SupplierViewModel>>(_supplierService.GetAll()));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(SupplierViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var supplier = AutoMapper.Mapper.Map<Supplier>(model);
                    supplier.CreatedBy = "";
                    supplier.CreatedDate = DateTime.Now;
                    supplier.Status = true;
                    supplier.UpdateBy = "";
                    supplier.UpdatedDate = DateTime.Now;

                    _supplierService.Insert(supplier);
                    _supplierService.SaveChanges();

                    return RedirectToAction("Index", "Supplier");
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
            return View(AutoMapper.Mapper.Map<SupplierViewModel>(_supplierService.GetByID(id)));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(SupplierViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var supplier = _supplierService.GetByID(model.ID);

                    supplier.Name = model.Name;
                    supplier.Address = model.Address;
                    supplier.Email = model.Email;
                    supplier.PhoneNumber = model.PhoneNumber;
                    supplier.Fax = model.Fax;
                    supplier.UpdateBy = "";
                    supplier.UpdatedDate = DateTime.Now;

                    _supplierService.Update(supplier);
                    _supplierService.SaveChanges();

                    return RedirectToAction("Index", "Supplier");
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
                var supplier = _supplierService.GetByID(id);

                _supplierService.Delete(supplier);
                _supplierService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}