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

        public virtual IEnumerable<ImportBillDetailViewModel> ImportBillDetails { get; set; } 

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdateBy { get; set; }

        public bool? Status { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
    }
}