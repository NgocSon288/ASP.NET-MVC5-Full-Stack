using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductDetailController(
            IProductService productService,
            ICommentService commentService)
        {
            this._productService = productService;
            this._commentService = commentService;
        }

        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            var model = AutoMapper.Mapper.Map<ProductViewModel>(_productService.GetByID(id));

            model.Comments = AutoMapper.Mapper.Map<List<CommentViewModel>>(_commentService.GetByProductID(id).ToList());

            return View(model);
        }
    }
}