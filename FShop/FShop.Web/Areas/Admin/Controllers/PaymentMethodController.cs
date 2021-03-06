﻿using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("PaymentMethod")]
    public class PaymentMethodController : BaseAdminController
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            this._paymentMethodService = paymentMethodService;
        }

        // GET: Admin/PaymentMethod
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<PaymentMethodViewModel>>(_paymentMethodService.GetAll().ToList()));
        }

        [HttpPost]
        public ActionResult Add(string description)
        {
            try
            {
                var paymentMethod = new PaymentMethod();

                paymentMethod.Description = description;
                paymentMethod.Status = 1;

                _paymentMethodService.Insert(paymentMethod);
                _paymentMethodService.SaveChanges();

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
                var paymentMethod = _paymentMethodService.GetByID(id);

                paymentMethod.Description = description;

                _paymentMethodService.Update(paymentMethod);
                _paymentMethodService.SaveChanges();

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
                _paymentMethodService.Delete(id);
                _paymentMethodService.SaveChanges();

                return Content("1");
            }
            catch (Exception)
            {
                return Content("0");
            }
        }
    }
}