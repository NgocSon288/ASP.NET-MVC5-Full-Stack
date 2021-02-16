using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FShop.Web.Models
{
    public class BrandViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Logo { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}