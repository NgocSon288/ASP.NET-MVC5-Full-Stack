using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class OrderStatusViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Status { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<OrderViewModel> Orders { get; set; }
    }
}