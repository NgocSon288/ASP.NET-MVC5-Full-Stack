using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace FShop.Web.Models
{
    public class BrandViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
         
        public string Logo { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string MetaKeyword { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string MetaDescription { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}