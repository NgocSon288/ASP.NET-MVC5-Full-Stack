using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class ImportBillController : Controller
    {
        private readonly IImportBillService _importBillService;

        public ImportBillController(IImportBillService importBillService)
        {
            this._importBillService = importBillService;
        }

        // GET: Admin/ImportBill
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<ImportBillViewModel>>(_importBillService.GetAll()));
        }
    }
}