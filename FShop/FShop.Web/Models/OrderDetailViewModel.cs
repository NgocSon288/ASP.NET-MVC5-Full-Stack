using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class OrderDetailViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Count { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [ForeignKey("OrderID")]
        public virtual OrderViewModel Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual ProductViewModel Product { get; set; }
    }
}