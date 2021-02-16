using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FShop.Web.Models
{
    public class ImportBillViewModel
    {
        [Key]
        public int ID { get; set; }

        //[Required]
        //public int SupplierID { get; set; }

        //[ForeignKey("SupplierID")]
        public virtual SupplierViewModel Supplier { get; set; }
    }
}