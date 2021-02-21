using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FShop.Web.Models
{
    public class PaymentMethodViewModel
    {
        [Key]
        public int ID { get; set; }

        public int Status { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        public virtual List<OrderViewModel> Orders { get; set; }
    }
}