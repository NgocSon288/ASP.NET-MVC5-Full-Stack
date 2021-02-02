using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("PaymentMethods")]
    public class PaymentMethod
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Status { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}