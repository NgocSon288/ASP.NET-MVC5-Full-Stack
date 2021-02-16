using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class SupplierViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Tên nhà cung cấp")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Fax { get; set; }

        public virtual IEnumerable<ImportBillViewModel> ImportBills { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}