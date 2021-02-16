using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FShop.Web.Models
{
    public class PaymentMethodViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Status { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<OrderViewModel> Orders { get; set; }
    }
}