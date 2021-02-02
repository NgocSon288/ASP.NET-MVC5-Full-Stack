using FShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("ImportBills")]
    public class ImportBill : Auditable
    {
        [Key]
        public int ID { get; set; }

        //[Required]
        //public int SupplierID { get; set; }

        //[ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }
    }
}