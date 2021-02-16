using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class SupplierViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public virtual IEnumerable<ImportBillViewModel> ImportBills { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}