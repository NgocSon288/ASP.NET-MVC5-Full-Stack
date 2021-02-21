using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace FShop.Web.Models
{
    public class AdvertisementViewModel
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Tên hiển thị")]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string URL { get; set; }

        [DisplayName("Thứ tự xuất hiện")]
        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdateBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}