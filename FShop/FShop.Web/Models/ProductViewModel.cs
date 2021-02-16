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

        [Required]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Alias { get; set; }

        [Required]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [Required]
        [DisplayName("Hình ảnh khác")]
        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Promotion { get; set; }

        public int Count { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsFreeShip { get; set; }

        public int ViewCount { get; set; }

        public bool IsInstallment { get; set; }

        public float Rating { get; set; }

        public int BuyCount { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required]
        public int SupplierID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("BrandID")]
        public BrandViewModel Brand { get; set; }

        [ForeignKey("SupplierID")]
        public SupplierViewModel Supplier { get; set; }

        [ForeignKey("CategoryID")]
        public ProductCategoryViewModel ProductCategory { get; set; }

        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
    }
}