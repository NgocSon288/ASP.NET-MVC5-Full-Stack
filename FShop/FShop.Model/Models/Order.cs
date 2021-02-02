using FShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Orders")]
    public class Order : Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("Địa chỉ")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string CustomerAddress { get; set; }

        [Required]
        [DisplayName("Email")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} phải tự {2} đến {1} ký tự")]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [Required]
        [Phone]
        public string CustomerMobile { get; set; }

        public string CustomerMessage { get; set; }

        public int? PaymentMethodID { get; set; }

        public int? MemberID { get; set; }

        public int? OrderStatusID { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [ForeignKey("PaymentMethodID")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("OrderStatusID")]
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}