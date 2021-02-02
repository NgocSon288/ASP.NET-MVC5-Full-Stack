using FShop.Model.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Comments")]
    public class Comment : Auditable
    {
        [Key]
        public int ID { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        [Required]
        public int StarNumber { get; set; }

        [Required]
        [DisplayName("Lý do")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string Reason { get; set; }

        [Required]
        [DisplayName("Mô tả")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string Description { get; set; }

        public string PostImage { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Member Member { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product{ get; set; }
    }
}