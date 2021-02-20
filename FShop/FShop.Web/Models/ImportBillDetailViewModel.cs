using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Web.Models
{
    public class ImportBillDetailViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public decimal ImportPrice { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int ImportBillID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public virtual ImportBillViewModel ImportBill { get; set; }
    }
}