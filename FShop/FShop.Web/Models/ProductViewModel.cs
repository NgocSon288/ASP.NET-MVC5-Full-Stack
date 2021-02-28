using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Web.Models
{
    public class ProductViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ  trống")]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ  trống")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Alias { get; set; }

        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [DisplayName("Hình ảnh khác")]
        public string MoreImage { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ  trống")]
        [DisplayName("Giá")]
        public decimal Price { get; set; }

        [DisplayName("Giảm giá")]
        public decimal Promotion { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ  trống")]
        [DisplayName("Số lượng tồn")]
        public int Count { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ  trống")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Cấu hình")]
        public string Content { get; set; }

        [DisplayName("Miễn phí ship")]
        public bool IsFreeShip { get; set; }

        [DisplayName("Lượt xem")]
        public int ViewCount { get; set; }

        [DisplayName("Cho phép trả góp")]
        public bool IsInstallment { get; set; }

        [DisplayName("Số sao trung bình")]
        public float Rating { get; set; }

        [DisplayName("Số lượt mua")]
        public int BuyCount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdateBy { get; set; }

        public bool? Status { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Nhãn hiệu")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Nhà cung cấp")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Loại sản phẩm")]
        public int CategoryID { get; set; }

        public BrandViewModel Brand { get; set; }

        [ForeignKey("SupplierID")]
        public SupplierViewModel Supplier { get; set; }

        [ForeignKey("CategoryID")]
        public ProductCategoryViewModel ProductCategory { get; set; }

        public virtual List<CommentViewModel> Comments { get; set; }
    }
}