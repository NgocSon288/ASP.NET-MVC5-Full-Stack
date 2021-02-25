using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("ImportBillDetail")]
    public class ImportBillDetailController : BaseAdminController
    {
        private readonly IImportBillDetailService _importBillDetailService;

        public ImportBillDetailController(IImportBillDetailService importBillDetailService)
        {
            this._importBillDetailService = importBillDetailService;
        }

        // GET: Admin/ImportBillDetail
        public ActionResult Index(int importBillID)
        {
            return View(AutoMapper.Mapper.Map<List<ImportBillDetailViewModel>>(_importBillDetailService.GetByImportBillID(importBillID).ToList()));
        }
    }
}