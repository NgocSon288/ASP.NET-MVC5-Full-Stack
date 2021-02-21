using FShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Advertisements")]
    public class Advertisement : Auditable
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }
    }
}