using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("Advertisement")]
    public class AdvertisementController : BaseAdminController
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            this._advertisementService = advertisementService;
        }

        // GET: Admin/Advertisement
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<AdvertisementViewModel>>(_advertisementService.GetAll()));
        }

        // GET: Admin/Advertisement
        public ActionResult Show()
        {
            return View(AutoMapper.Mapper.Map<List<AdvertisementViewModel>>(_advertisementService.GetAll().ToList().OrderBy(ad=>ad.DisplayOrder)));
        }

        [HttpGet]
        public ActionResult Add()
        {
            Setup();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(AdvertisementViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra có chọn hình ảnh hay không
                    if (model.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        model.Image = fileName + extension;

                        if (_advertisementService.GetAll().Any(ad => ad.Image == model.Image))
                        {
                            ModelState.AddModelError("Image", "Hình ảnh đã tồn tại");

                            return View(model);
                        }

                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Advertisement/"), model.Image));

                        model.CreatedBy = GetMemberSession().DisplayName;
                        model.CreatedDate = DateTime.Now;
                        model.UpdateBy = "";
                        model.UpdatedDate = null;
                        model.Status = true;
                        model.MetaKeyword = "";
                        model.MetaDescription = "";

                        var advertisement = AutoMapper.Mapper.Map<Advertisement>(model);

                        var advertisements = _advertisementService.GetAll().ToList();
                        var maxCount = advertisements.Count() + 1;

                        if (advertisement.DisplayOrder != maxCount)
                        {
                            var adver = advertisements.FirstOrDefault(ad => ad.DisplayOrder == advertisement.DisplayOrder);

                            adver.DisplayOrder = maxCount;
                        }

                        _advertisementService.Insert(advertisement);
                        _advertisementService.SaveChanges();

                        return RedirectToAction("Index", "Advertisement");
                    }
                }
                catch (Exception e)
                {

                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Setup(false);

            return View(AutoMapper.Mapper.Map<AdvertisementViewModel>(_advertisementService.GetByID(id)));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(AdvertisementViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    model.Image = fileName + extension;

                    if (_advertisementService.GetAll().Any(ad => ad.Image == model.Image && ad.ID != model.ID))
                    {
                        ModelState.AddModelError("Image", "Hình ảnh đã tồn tại");
                        Setup(false);

                        return View(model);
                    }

                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Advertisement/"), model.Image));

                }

                var advertisement = _advertisementService.GetByID(model.ID);

                if (advertisement.DisplayOrder != model.DisplayOrder)
                {
                    var adTemp = _advertisementService.GetByDisplayOrder(model.DisplayOrder.Value);

                    adTemp.DisplayOrder = advertisement.DisplayOrder;

                    _advertisementService.SaveChanges();
                }

                advertisement.Name = model.Name;
                advertisement.Description = model.Description;
                advertisement.Image = model.Image;
                advertisement.UpdateBy = GetMemberSession().DisplayName;
                advertisement.UpdatedDate = DateTime.Now;
                advertisement.DisplayOrder = model.DisplayOrder;



                _advertisementService.Update(advertisement);
                _advertisementService.SaveChanges();
            }

            return RedirectToAction("Index", "Advertisement");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var advertisement = _advertisementService.GetByID(id);
                _advertisementService.Delete(id);

                var advertisements = _advertisementService.GetAll().Where(ad=>ad.DisplayOrder>advertisement.DisplayOrder).ToList();

                advertisements.ForEach(ad => ad.DisplayOrder--);

                _advertisementService.SaveChanges();

                return RedirectToAction("Index", "Advertisement");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Advertisement");
            }
        }

        #region Method
        private void Setup(bool isAdd = true)
        {
            List<int> displayOrder = new List<int>() { 1 };
            var count = _advertisementService.GetAll().Count();

            if (count >= 1)
            {
                for (var i = 2; i <= count; i++)
                {
                    displayOrder.Add(i);
                }

                if (isAdd)
                {
                    displayOrder.Add(count + 1);
                }
            }

            ViewBag.displayOrder = displayOrder;
        }

        #endregion
    }
}