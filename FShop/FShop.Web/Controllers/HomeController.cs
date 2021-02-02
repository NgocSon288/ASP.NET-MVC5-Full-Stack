using FShop.Service.Services;
using FShop.Web.Infrastructure.Core;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAdvertisementService _advertisementService;
        public HomeController(IAdvertisementService advertisementService)
        {
            this._advertisementService = advertisementService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var advertisements = _advertisementService.GetAll().ToList();
            var advertisementVMs = AutoMapper.Mapper.Map<List<AdvertisementViewModel>>(advertisements);

            ViewBag.Hello = "Hello world, my name is Son";
            return View(advertisementVMs);
        }
    }
}