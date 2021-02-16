﻿using FShop.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class OrderViewModel
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
        public virtual MemberViewModel Member { get; set; }

        [ForeignKey("PaymentMethodID")]
        public virtual PaymentMethodViewModel PaymentMethod { get; set; }

        [ForeignKey("OrderStatusID")]
        public virtual OrderStatusViewModel OrderStatus { get; set; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}