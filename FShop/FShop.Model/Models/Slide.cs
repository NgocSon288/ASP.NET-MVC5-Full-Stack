using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FShop.Model.Models
{
    [Table("Slides")]
    public class Slide
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        [Required]
        public string Image { get; set; }

        public bool Status { get; set; }
    }
}