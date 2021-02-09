using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    public class MemberController : BaseAdminController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            this._memberService = memberService;
        }

        // GET: Admin/Member
        public ActionResult Index()
        {
            var members = _memberService.GetAll().ToList();

            var memberVMs = AutoMapper.Mapper.Map<List<MemberViewModel>>(members);
            return View(memberVMs);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int memberID)
        {
            try
            {
                var member = _memberService.GetByID(memberID);
                member.MemberStatusID = member.MemberStatusID == 1 ? 3 : 1;

                _memberService.Update(member);
                _memberService.SaveChanges();

                return Content("1");
            }
            catch (System.Exception e)
            {
                return Content("0");
            }
        }

        [HttpPost]
        public ActionResult DeleteMember(int memberID)
        {
            try
            {
                _memberService.Delete(memberID);
                _memberService.SaveChanges();

                return Content("1");
            }
            catch (System.Exception e)
            {
                return Content("0");
            }
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMember(MemberViewModel Model)
        {
            var check = true;

            if (ModelState.IsValid)
            {
                if (Model.PassWord != Model.ConfirmPassWord)
                {
                    ModelState.AddModelError("ConfirmPassWord", "Xác nhận mật khẩu không hợp lệ");
                    check = false;
                }

                if (Model.ImageUpload == null)
                {
                    ModelState.AddModelError("Avatar", "Ảnh đại diện không được để trống!");
                    check = false;
                }

                var memberCheck = await _memberService.GetByUserName(Model.UserName);

                if (memberCheck != null)
                {
                    ModelState.AddModelError("UserName", "Tài khoản đã có người sử dụng!");
                    check = false;
                }

                // Email không hợp lệ...

                if (!check)
                {
                    return View(Model);
                }

                try
                {
                    // Kiểm tra có chọn hình ảnh hay không
                    if (Model.ImageUpload != null)
                    {
                        // VD: hình ảnh chọn là Images/hinh1.jpg
                        // Lấy ra tên của hình ảnh: hinh1
                        string fileName = Path.GetFileNameWithoutExtension(Model.ImageUpload.FileName);

                        // Lấy ra đuôi mở rộng của hình ảnh
                        string extension = Path.GetExtension(Model.ImageUpload.FileName);

                        // Gán dữ liệu vào Model để có thể lưu xuống DB
                        Model.Avatar = fileName + extension;

                        // Lưu hình ảnh vào thư mục
                        Model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages"), Model.Avatar));

                        Model.IsAnotherIdentity = "1";
                        Model.MemberStatusID = 1;

                        var member = AutoMapper.Mapper.Map<Member>(Model);

                        member.CreatedBy = "1";
                        member.CreatedDate = DateTime.Now;
                        member.UpdateBy = "1";
                        member.UpdatedDate = DateTime.Now;
                        member.Status = true;

                        _memberService.Insert(member);
                        _memberService.SaveChanges();
                    }
                }
                catch (Exception e)
                {

                }
            }

            return RedirectToAction("Index");
        }
    }
}