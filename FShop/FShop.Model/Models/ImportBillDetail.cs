using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("ImportBillDetails")]
    public class ImportBillDetail
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

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("ImportBillID")]

        public virtual ImportBill ImportBill { get; set; }
    }
}