using FShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("ImportBills")]
    public class ImportBill : Auditable
    {
        [Key]
        public int ID { get; set; }

        public virtual IEnumerable<ImportBillDetail> ImportBillDetails { get; set; } 
    }
}