using FShop.Common;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IProductService _productService;

        public HomeController(IAdvertisementService advertisementService, IProductService productService)
        {
            this._advertisementService = advertisementService;
            this._productService = productService;
        }

        // GET: Home
        public ActionResult Index()
        {
            //return RedirectToRoute("TestLoginAdmin");
            ViewBag.slides = AutoMapper.Mapper.Map<List<AdvertisementViewModel>>(_advertisementService.GetByCount(Constants.SLIDE_COUNT));
            ViewBag.cellPhones = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetByCategoryID(1,4));
            ViewBag.smartWatchs = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetByCategoryID(2,2));
            ViewBag.laptops = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetByCategoryID(3,3));
            ViewBag.tablets = AutoMapper.Mapper.Map<List<ProductViewModel>>(_productService.GetByCategoryID(4,2));

            return View();
        }
    }
}