using FShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("ProductCategorys")]
    public class ProductCategory : Auditable
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Tên loại sản phẩm")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Alias { get; set; }

        [Required]
        public string Description { get; set; }
         
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Icon { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}