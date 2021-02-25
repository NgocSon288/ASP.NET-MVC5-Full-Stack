using FShop.Model.Models;
using FShop.Service.Services;
using FShop.Web.Infrastructure.Extensions;
using FShop.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FShop.Web.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute("Member")]
    public class MemberController : BaseAdminController
    {
        private readonly IMemberService _memberService;
        private readonly IMemberStatusService _memberStatusService;

        public MemberController(IMemberService memberService, IMemberStatusService memberStatusService)
        {
            this._memberService = memberService;
            this._memberStatusService = memberStatusService;
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
            catch (System.Exception)
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
            catch (System.Exception)
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
        public async Task<ActionResult> MemberInsert(MemberViewModel model)
        {
            var check = true;

            if (ModelState.IsValid)
            {
                if (model.PassWord != model.ConfirmPassWord)
                {
                    ModelState.AddModelError("ConfirmPassWord", "Xác nhận mật khẩu không hợp lệ");
                    check = false;
                }

                if (model.ImageUpload == null)
                {
                    ModelState.AddModelError("Avatar", "Ảnh đại diện không được để trống!");
                    check = false;
                }

                var memberCheck = await _memberService.GetByUserName(model.UserName);

                if (memberCheck != null)
                {
                    ModelState.AddModelError("UserName", "Tài khoản đã có người sử dụng!");
                    check = false;
                }

                // Email không hợp lệ...

                if (!check)
                {
                    return View(model);
                }

                try
                {
                    // Kiểm tra có chọn hình ảnh hay không
                    if (model.ImageUpload != null)
                    {
                        // VD: hình ảnh chọn là Images/hinh1.jpg
                        // Lấy ra tên của hình ảnh: hinh1
                        //string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);   // tên theo tên hình
                        string fileName = model.UserName;   // tên theo userName

                        // Lấy ra đuôi mở rộng của hình ảnh
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        // Gán dữ liệu vào Model để có thể lưu xuống DB
                        model.Avatar = fileName + extension;

                        // Lưu hình ảnh vào thư mục
                        model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Member/"), model.Avatar));

                        model.IsAnotherIdentity = "1";
                        model.MemberStatusID = 1;

                        var member = AutoMapper.Mapper.Map<Member>(model);

                        member.CreatedBy = "1";
                        member.CreatedDate = DateTime.Now;
                        member.UpdateBy = "1";
                        member.UpdatedDate = DateTime.Now;
                        member.Status = true;

                        _memberService.Insert(member);
                        _memberService.SaveChanges();
                    }
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> MemberUpdate(int memberID)
        {
            var member = AutoMapper.Mapper.Map<MemberUpdateInputViewModel>(_memberService.GetByID(memberID));
            SetMemberStatus();

            return View(member);
        }

        private void SetMemberStatus()
        {
            var memberStatus = _memberStatusService.GetAll().ToList();
            SelectList selectList = new SelectList(memberStatus, "ID", "Description");

            ViewBag.memberStatus = selectList;
        }

        [HttpPost]
        public async Task<ActionResult> MemberUpdate(MemberUpdateInputViewModel model)
        {
            bool check = true;
            if (ModelState.IsValid)
            {
                var member = _memberService.GetByID(model.ID);

                if (model.OldPassWord != null && model.OldPassWord != "")
                {
                    if (model.OldPassWord != member.PassWord)
                    {
                        ModelState.AddModelError("OldPassWord", "Mật khẩu hiện tại không trùng khớp!");
                        check = false;
                    }

                    if (model.NewPassWord != model.ConfirmNewPassWord)
                    {
                        ModelState.AddModelError("ConfirmNewPassWord", "Xác nhận mật khẩu không trùng khớp!");
                        check = false;
                    }
                }

                // Email hợp lệ

                if (model.ImageUpload != null && check)
                {
                    string fileName = model.UserName;   // tên theo userName

                    // Lấy ra đuôi mở rộng của hình ảnh
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    // Gán dữ liệu vào Model để có thể lưu xuống DB
                    model.Avatar = fileName + extension;

                    // Lưu hình ảnh vào thư mục
                    model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Admin/images/MyImages/Member/"), model.Avatar));
                }

                if (!check)
                {
                    SetMemberStatus();
                    return View(model);
                }
                else
                {
                    member.PassWord =  string.IsNullOrEmpty(model.NewPassWord) ? member.PassWord : model.NewPassWord;
                    member.Address = model.Address;
                    member.Avatar = model.Avatar;
                    member.DisplayName = model.DisplayName;
                    member.Email = model.Email;
                    member.MemberStatusID = model.MemberStatusID;
                    member.UpdateBy = "1";
                    member.UpdatedDate = DateTime.Now;

                    try
                    {
                        _memberService.Update(member);
                        _memberService.SaveChanges();

                        // cập nhật lại session
                        //var member = Session[FShop.Common.Constants.MEMBER_SESSION] as FShop.Common.ModelSession.MemberSession;

                        SetMemberSession(member);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
             
            return RedirectToAction("Index", "Member");
        }
    }
}