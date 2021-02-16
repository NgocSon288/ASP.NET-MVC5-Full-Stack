using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Tên loại sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Alias { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }
         
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Icon { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string MetaKeyword { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string MetaDescription { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
         
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}