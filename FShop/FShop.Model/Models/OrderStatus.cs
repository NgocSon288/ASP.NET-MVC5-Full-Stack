using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("OrderStatuses")]
    public class OrderStatus
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Status { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}